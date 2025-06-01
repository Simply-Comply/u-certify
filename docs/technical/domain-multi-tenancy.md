# U-Certify Multi-Tenancy Design

## Overview

This document outlines the multi-tenancy architecture for the U-Certify platform, where each **Conformity Assessment Body (CAB)** operates as an independent tenant with complete data isolation and customizable business rules.

**Architecture**: Multi-Tenant SaaS Platform  
**Tenant Model**: CAB-per-Tenant  
**Isolation Strategy**: Logical separation with domain-enforced boundaries  
**Tenant Identification**: CAB ID serves as primary tenant identifier

---

## Multi-Tenancy Design Approach

### Tenant Model
In UCertify, each **Conformity Assessment Body (CAB)** represents a separate tenant:

- **Tenant**: CAB organization (e.g., "ABC Certification Ltd", "Quality Assurance Corp")
- **Tenant Isolation**: All aggregates are scoped to a specific CAB
- **Data Separation**: Logical separation with CAB-scoped data access
- **Business Rules**: Some rules are tenant-specific (CAB accreditation scope, policies)
- **Customization**: Tenant-specific workflows, branding, and configurations

### Domain-Aware Multi-Tenancy

**Approach**: **Domain-Aware Multi-Tenancy**
- Tenant context is part of the domain model (not just infrastructure)
- All aggregate roots include tenant identification
- Business rules can be tenant-specific
- Domain services are tenant-scoped
- Cross-tenant operations are explicitly prevented at domain level

---

## Tenant-Aware Domain Patterns

### 1. Tenant-Aware Base Classes

```csharp
// Base interface for tenant-aware entities
public interface ITenantAware
{
    CABId TenantId { get; }
}

// Base class for tenant-scoped IDs
public abstract class TenantScopedId : ValueObject
{
    public CABId TenantId { get; private set; }
    public string Value { get; private set; }
    
    protected TenantScopedId(CABId tenantId, string value)
    {
        TenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    // Ensures uniqueness within tenant scope
    public override string ToString() => $"{TenantId}:{Value}";
}

// Base class for tenant-aware domain events
public abstract class TenantAwareDomainEvent : DomainEvent
{
    public CABId TenantId { get; private set; }
    
    protected TenantAwareDomainEvent(CABId tenantId)
    {
        TenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
    }
}
```

### 2. Tenant Context Injection

```csharp
public interface ITenantContext
{
    CABId CurrentTenantId { get; }
    bool IsSystemContext { get; } // For platform-level operations
    bool HasTenantAccess(CABId tenantId);
}

// Domain services are tenant-scoped
public class AuditPlanningService
{
    private readonly ITenantContext _tenantContext;
    
    public AuditPlanningService(ITenantContext tenantContext)
    {
        _tenantContext = tenantContext;
    }
    
    public AuditPlan CreateAuditPlan(Assessment assessment)
    {
        // Automatically scoped to current tenant
        EnsureTenantAccess(assessment.TenantId);
            
        // Business logic...
        return new AuditPlan(assessment, _tenantContext.CurrentTenantId);
    }
    
    private void EnsureTenantAccess(CABId tenantId)
    {
        if (!_tenantContext.HasTenantAccess(tenantId))
            throw new TenantIsolationViolationException(
                $"Access denied to tenant {tenantId} from context {_tenantContext.CurrentTenantId}");
    }
}
```

### 3. Repository Tenant Filtering

```csharp
public interface IApplicationRepository
{
    // All operations automatically scoped to current tenant
    Task<Application> GetByIdAsync(ApplicationId id);
    Task<IEnumerable<Application>> GetByStatusAsync(ApplicationStatus status);
    Task<Application> GetByClientAndStandardAsync(ClientId clientId, CertificationStandard standard);
    
    // Tenant isolation enforced at repository level
    // No cross-tenant queries possible
}

// Implementation automatically filters by current tenant
public class ApplicationRepository : IApplicationRepository
{
    private readonly ITenantContext _tenantContext;
    private readonly IDbContext _context;
    
    public async Task<Application> GetByIdAsync(ApplicationId id)
    {
        return await _context.Applications
            .Where(a => a.TenantId == _tenantContext.CurrentTenantId)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }
}
```

---

## Tenant-Specific Aggregate Modifications

### Application Aggregate (Tenant-Aware)

```csharp
public class Application : AggregateRoot<ApplicationId>, ITenantAware
{
    public CABId TenantId { get; private set; }
    public ApplicationId Id { get; private set; }
    public ClientId ClientId { get; private set; }
    public ApplicationStatus Status { get; private set; }
    // ... other properties
    
    private Application() { } // For EF
    
    public Application(
        ApplicationId id, 
        ClientId clientId, 
        CABId tenantId,
        CertificationScope scope,
        ContactInformation contact)
    {
        Id = id;
        ClientId = clientId;
        TenantId = tenantId;
        Status = ApplicationStatus.Received;
        
        // Ensure client belongs to same tenant
        if (clientId.TenantId != tenantId)
            throw new TenantIsolationViolationException(
                "Client must belong to the same tenant as application");
        
        AddDomainEvent(new ApplicationReceived(Id, TenantId));
    }
    
    public void AssignToReviewer(AuditorId reviewerId)
    {
        // Ensure reviewer belongs to same tenant
        if (reviewerId.TenantId != TenantId)
            throw new TenantIsolationViolationException(
                "Reviewer must belong to the same tenant");
                
        // Business logic...
    }
}
```

### Tenant-Scoped Value Objects

```csharp
public class ApplicationId : TenantScopedId
{
    private ApplicationId(CABId tenantId, string value) : base(tenantId, value) { }
    
    public static ApplicationId Create(CABId tenantId, int sequenceNumber, int year)
    {
        var value = $"APP-{year:yyyy}-{sequenceNumber:00000}";
        return new ApplicationId(tenantId, value);
    }
    
    public static ApplicationId Parse(string value)
    {
        // Parse format: "tenantId:APP-2025-00001"
        var parts = value.Split(':');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid ApplicationId format");
            
        var tenantId = CABId.Parse(parts[0]);
        return new ApplicationId(tenantId, parts[1]);
    }
}
```

---

## Multi-Tenant Project Structure Extensions

```
UCertify.Domain/
├── MultiTenancy/
│   ├── ITenantContext.cs                 // Tenant context abstraction
│   ├── ITenantAware.cs                   // Marker interface for tenant-scoped entities
│   ├── TenantScopedId.cs                 // Base class for tenant-aware identifiers
│   ├── TenantAwareDomainEvent.cs         // Base class for tenant-aware events
│   ├── TenantScope.cs                    // Tenant scope value object
│   ├── TenantIsolationViolationException.cs // Domain exception for tenant violations
│   └── TenantSpecification.cs            // Base specification for tenant filtering
│
├── Aggregates/
│   ├── Applications/
│   │   ├── Application.cs                // implements ITenantAware
│   │   ├── ValueObjects/
│   │   │   ├── ApplicationId.cs          // extends TenantScopedId
│   │   │   └── ...
│   │   ├── Events/
│   │   │   ├── ApplicationReceived.cs    // extends TenantAwareDomainEvent
│   │   │   └── ...
│   │   └── Specifications/
│   │       ├── TenantApplicationAccess.cs // Tenant access validation
│   │       └── ...
│   │
│   └── CABConfiguration/
│       ├── ConformityAssessmentBody.cs   // The Tenant Entity
│       ├── TenantConfiguration.cs        // Tenant-specific settings
│       └── ValueObjects/
│           ├── CABId.cs                  // Primary Tenant Identifier
│           ├── TenantSettings.cs         // Customizable tenant options
│           └── ...
│
├── DomainServices/
│   ├── TenantManagementService.cs        // Platform-level tenant operations
│   ├── CertificationProcessOrchestrator.cs // Tenant-scoped
│   └── ...
│
└── SharedKernel/
    ├── Exceptions/
    │   └── TenantIsolationViolationException.cs
    └── Specifications/
        └── TenantAwareSpecification.cs    // Base for tenant-scoped specifications
```

---

## Key Multi-Tenant Design Considerations

### 1. Data Isolation Strategies

**Logical Separation (Chosen Approach)**
- All queries include tenant filter automatically
- Single database with tenant-aware data access
- Cost-effective for large number of small-medium tenants
- Simplified backup/restore operations

**Benefits:**
- Lower infrastructure costs
- Easier maintenance and updates
- Efficient resource utilization
- Simplified monitoring

**Considerations:**
- Requires robust tenant filtering at all levels
- Risk of tenant data leakage if not properly implemented
- Performance may degrade with very large tenants

### 2. Business Rules & Customization

**Global Rules (ISO 17021 Compliance)**
```csharp
public class ISO17021ComplianceRule : Specification<Assessment>
{
    // Applies to ALL tenants - no customization allowed
    public override Expression<Func<Assessment, bool>> ToExpression()
    {
        return assessment => 
            assessment.Duration.TotalHours >= MinimumAuditHours(assessment.ClientSize) &&
            assessment.Findings.All(f => f.HasObjectiveEvidence);
    }
}
```

**Tenant-Specific Rules**
```csharp
public class CABSpecificAuditRule : TenantAwareSpecification<Assessment>
{
    public CABSpecificAuditRule(ITenantContext tenantContext) : base(tenantContext) { }
    
    public override Expression<Func<Assessment, bool>> ToExpression()
    {
        var tenantSettings = GetTenantSettings();
        
        return assessment => 
            assessment.TenantId == CurrentTenantId &&
            assessment.Duration.TotalHours >= tenantSettings.MinimumAuditDuration;
    }
}
```

### 3. Certificate Numbering Strategy

**Globally Unique with CAB Branding**
```csharp
public class CertificateNumber : ValueObject
{
    public CABId TenantId { get; private set; }
    public string Number { get; private set; }
    
    private CertificateNumber(CABId tenantId, string number)
    {
        TenantId = tenantId;
        Number = number;
    }
    
    public static CertificateNumber Generate(CABId tenantId, int sequenceNumber, int year)
    {
        var cabPrefix = GetCABPrefix(tenantId); // e.g., "ABC", "QAC"
        var number = $"{cabPrefix}-{year:yyyy}-{sequenceNumber:000}";
        return new CertificateNumber(tenantId, number);
    }
    
    // Globally unique across all tenants
    public string GlobalIdentifier => Number;
    
    // Searchable in public certificate registry
    public bool IsPubliclySearchable => true;
}
```

### 4. Security & Access Control

**Tenant-Scoped User Management**
```csharp
public class User : Entity<UserId>, ITenantAware
{
    public CABId TenantId { get; private set; }
    public UserId Id { get; private set; }
    public UserRole Role { get; private set; }
    
    // Users can only access resources within their tenant
    public bool CanAccess(ITenantAware resource)
    {
        return resource.TenantId == TenantId;
    }
}

// Role-based permissions within tenant
public enum UserRole
{
    CABAdministrator,    // Full access within tenant
    QualityManager,      // Compliance and internal audit access
    LeadAuditor,         // Assessment management
    Auditor,             // Assessment execution
    AdministrativeStaff  // Limited data entry and scheduling
}
```

---

## Tenant Management Operations

### CAB Onboarding Process

```csharp
public class TenantManagementService
{
    public async Task<ConformityAssessmentBody> OnboardNewCAB(
        string legalName,
        AccreditationDetails accreditation,
        ContactInformation primaryContact)
    {
        var cabId = CABId.GenerateNew();
        
        var cab = new ConformityAssessmentBody(
            cabId,
            legalName,
            accreditation,
            primaryContact);
            
        // Setup default tenant configuration
        var defaultConfig = TenantConfiguration.CreateDefault(cabId);
        cab.ApplyConfiguration(defaultConfig);
        
        // Create initial administrative user
        var adminUser = User.CreateCABAdministrator(cabId, primaryContact.Email);
        
        await _cabRepository.AddAsync(cab);
        await _userRepository.AddAsync(adminUser);
        
        // Raise tenant creation event
        cab.AddDomainEvent(new CABRegistered(cabId, legalName));
        
        return cab;
    }
}
```

### Tenant Configuration Management

```csharp
public class TenantConfiguration : ValueObject
{
    public TimeSpan DefaultAuditDuration { get; private set; }
    public bool RequireWitnessActivities { get; private set; }
    public int MaxSurveillanceInterval { get; private set; }
    public string CertificateTemplate { get; private set; }
    public bool AllowRemoteAudits { get; private set; }
    
    public static TenantConfiguration CreateDefault(CABId tenantId)
    {
        return new TenantConfiguration
        {
            DefaultAuditDuration = TimeSpan.FromDays(2),
            RequireWitnessActivities = false,
            MaxSurveillanceInterval = 12, // months
            CertificateTemplate = "standard",
            AllowRemoteAudits = true
        };
    }
}
```

---

## Integration Considerations

### Cross-Tenant Operations

**Permitted Cross-Tenant Operations:**
- Public certificate verification
- Anonymous benchmarking data
- Platform-level reporting (aggregated)
- System maintenance operations

**Forbidden Cross-Tenant Operations:**
- Direct access to another CAB's data
- Cross-tenant auditor assignments
- Shared client data
- Cross-tenant compliance information

### External System Integration

```csharp
public class ExternalIntegrationService
{
    // Tenant-specific integrations
    public async Task SyncWithAccreditationBody(CABId tenantId)
    {
        var cab = await _cabRepository.GetByIdAsync(tenantId);
        var integration = _integrationFactory.CreateFor(cab.AccreditationBody);
        
        // Sync compliance data specific to this CAB
        await integration.SyncComplianceData(tenantId);
    }
}
```

---

## Performance & Scalability

### Tenant Data Distribution

**Small-Medium CABs (< 1000 certificates)**
- Shared database with logical separation
- Standard indexing strategy
- Regular maintenance windows

**Large CABs (> 1000 certificates)**
- Consider dedicated read replicas
- Enhanced indexing strategies
- Priority support and maintenance

**Enterprise CABs (> 10,000 certificates)**
- Dedicated database instances
- Custom SLA agreements
- 24/7 support

### Monitoring & Alerting

**Per-Tenant Metrics:**
- Active certificate count
- Monthly assessment volume
- Compliance score
- User activity levels
- System performance

**Platform-Level Metrics:**
- Total tenant count
- System-wide performance
- Security incidents
- Data integrity checks

---

## Future Multi-Tenant Enhancements

### Phase 2 Considerations

**Cross-Tenant Analytics**
- Anonymous benchmarking reports
- Industry trend analysis
- Performance comparisons
- Best practice sharing

**Tenant Hierarchies**
- CAB subsidiaries support
- Shared resource management
- Consolidated reporting
- Group-level administration

**White-Label Solutions**
- Tenant-branded interfaces
- Custom domain support
- Personalized workflows
- CAB-specific terminology

**Regional Compliance**
- Data residency requirements
- Local language support
- Region-specific business rules
- Compliance with local laws

---

*Document Version: 1.0*  
*Last Updated: 2025-01-22*  
*Review Frequency: Quarterly*

**Note**: Multi-tenancy is a foundational architectural decision that impacts every aspect of the platform. This design ensures complete tenant isolation while enabling efficient resource sharing and platform management. 