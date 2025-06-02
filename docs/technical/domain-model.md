# U-Certify Domain Model Analysis

## Overview

This document analyzes the business requirements from the U-Certify platform and defines the domain model including entities, value objects, aggregates, and the recommended project structure for the `UCertify.Domain` project.

**Domain**: Conformity Assessment Body (CAB) Management System  
**Standards Focus**: ISO/IEC 17021-1:2015 - Management System Certification Bodies  
**Business Context**: Certification lifecycle management from application to certificate maintenance  
**Architecture**: **Multi-Tenant SaaS Platform** - Each CAB operates as an independent tenant

---

## Multi-Tenancy Design Approach

### Tenant Model

In UCertify, each **Conformity Assessment Body (CAB)** represents a separate tenant with complete data isolation:

- **Tenant**: CAB organization (e.g., "ABC Certification Ltd")
- **Tenant Isolation**: All aggregates are scoped to a specific CAB
- **Data Separation**: Logical separation with CAB-scoped data access
- **Business Rules**: Some rules are tenant-specific (CAB accreditation scope, policies)

### Tenant-Aware Domain Design

**Approach**: **Domain-Aware Multi-Tenancy**

- Tenant context is part of the domain model (not just infrastructure)
- All aggregate roots include tenant identification
- Business rules can be tenant-specific
- Domain services are tenant-scoped

---

## Domain Boundaries

The U-Certify platform operates within three main bounded contexts, all **tenant-scoped**:

1. **Certification Management**: Core business process from application to certificate issuance **(per CAB)**
2. **Compliance Management**: Accreditation requirements tracking and evidence management **(per CAB)**  
3. **Resource Management**: Auditor competencies, scheduling, and CAB operations **(per CAB)**

---

## Aggregates and Aggregate Roots

### 1. Application Aggregate

**Aggregate Root**: `Application`  
**Tenant Scope**: CAB-specific

The Application aggregate manages the initial certification request lifecycle, from submission through approval/rejection **within a specific CAB**.

**Entities:**

- `Application` *(Aggregate Root)* - Primary certification request
- `ApplicationReview` - Review process and decisions
- `ApplicationDocument` - Supporting documentation

**Value Objects:**

- `ApplicationId` - Unique identifier (APP-YYYY-NNNNN format) - **tenant-scoped uniqueness**
- `ApplicationStatus` - Workflow state (Received, Under Review, Approved, etc.)
- `CertificationScope` - Description of activities to be certified
- `ContactInformation` - Client contact details
- `ApplicationSubmissionDetails` - Channel, timestamp, source
- `TenantId` - CAB identifier for tenant isolation

**Invariants:**

- Application must have unique identifier once created **within CAB tenant**
- Status transitions must follow defined workflow
- Mandatory fields must be complete before proceeding
- Scope description must be substantive (>50 characters)
- **Application belongs to exactly one CAB tenant**

---

### 2. Assessment Aggregate  

**Aggregate Root**: `Assessment`  
**Tenant Scope**: CAB-specific

The Assessment aggregate encapsulates the entire audit process including planning, execution, and findings **within a specific CAB**.

**Entities:**

- `Assessment` *(Aggregate Root)* - Main audit/assessment process
- `AuditPlan` - Detailed audit planning and schedule
- `AuditTeam` - Team composition and roles
- `Finding` - Individual audit findings and nonconformities
- `CorrectiveAction` - Client responses to findings
- `AuditSession` - Daily audit activities and evidence collection

**Value Objects:**

- `AssessmentId` - Unique assessment identifier - **tenant-scoped**
- `AssessmentType` - Stage 1, Stage 2, Surveillance, Recertification
- `AssessmentStatus` - Planned, In Progress, Completed, Report Issued
- `AuditDuration` - Time allocation based on organization size
- `FindingClassification` - Major NC, Minor NC, Observation, OFI
- `AuditEvidence` - Objective evidence supporting findings
- `AssessmentRecommendation` - Recommend/Conditional/Do Not Recommend
- `TenantId` - CAB identifier for tenant isolation

**Invariants:**

- Stage 2 cannot start without completed Stage 1
- Assessment duration must meet ISO 17021 minimums
- All findings must have supporting objective evidence
- Lead auditor must make clear recommendation
- **Assessment can only be conducted by auditors from the same CAB tenant**
- **Assessment can only reference clients from the same CAB tenant**

---

### 3. Client Aggregate

**Aggregate Root**: `Client`  
**Tenant Scope**: CAB-specific

The Client aggregate manages organization information, sites, and certification history **within a specific CAB**.

**Entities:**

- `Client` *(Aggregate Root)* - Client organization
- `Site` - Physical locations within certification scope
- `CertificationHistory` - Previous and current certifications

**Value Objects:**

- `ClientId` - Unique client identifier - **tenant-scoped**
- `LegalEntityName` - Official organization name
- `Address` - Physical address details
- `EmployeeCount` - FTE count for audit duration calculation
- `MultiSiteConfiguration` - Central office designation and site relationships
- `PreviousCertificationDetails` - Transfer information from other CABs
- `TenantId` - CAB identifier for tenant isolation

**Invariants:**

- Client must have at least one site
- Multi-site clients must designate central office
- Legal entity name must be unique **within CAB tenant**
- Employee count must be greater than zero
- **Client belongs to exactly one CAB tenant**

---

### 4. Certificate Aggregate

**Aggregate Root**: `Certificate`  
**Tenant Scope**: CAB-specific

The Certificate aggregate manages the certification lifecycle and maintenance **within a specific CAB**.

**Entities:**

- `Certificate` *(Aggregate Root)* - Issued certification document
- `CertificateScope` - Detailed scope of certification
- `SurveillanceSchedule` - Ongoing surveillance audit planning

**Value Objects:**

- `CertificateId` - Unique certificate identifier - **tenant-scoped**
- `CertificateNumber` - Public certificate reference - **globally unique but CAB-branded**
- `CertificationStandard` - ISO 9001, 14001, 45001, etc.
- `CertificateStatus` - Active, Suspended, Withdrawn, Expired
- `ValidityPeriod` - Issue date, expiry date, 3-year cycle
- `CertificationDecision` - Grant, Refuse, Conditional grant
- `TenantId` - CAB identifier for tenant isolation

**Invariants:**

- Certificate validity period must be exactly 3 years
- Certificate number must be unique **globally** (includes CAB prefix)
- Status transitions must follow certification rules
- Suspension requires documented justification
- **Certificate can only be issued by the owning CAB tenant**

---

### 5. Auditor Aggregate

**Aggregate Root**: `Auditor`  
**Tenant Scope**: CAB-specific

The Auditor aggregate manages auditor information, competencies, and availability **within a specific CAB**.

**Entities:**

- `Auditor` *(Aggregate Root)* - Individual auditor
- `Competence` - Standard-specific qualifications
- `Assignment` - Audit assignments and roles
- `ProfessionalDevelopment` - CPD tracking

**Value Objects:**

- `AuditorId` - Unique auditor identifier - **tenant-scoped**
- `AuditorRole` - Lead Auditor, Auditor, Technical Expert
- `CompetenceMatrix` - Standards and sectors qualified for
- `Availability` - Schedule and capacity
- `ConflictOfInterest` - Client relationship restrictions
- `TenantId` - CAB identifier for tenant isolation

**Invariants:**

- Lead auditors must have appropriate qualifications
- Conflict of interest must be checked for all assignments **within CAB**
- CPD requirements must be maintained
- Competence must be current for assigned standards
- **Auditor belongs to exactly one CAB tenant**
- **Auditor can only be assigned to assessments within their CAB**

---

### 6. CAB Configuration Aggregate

**Aggregate Root**: `ConformityAssessmentBody`  
**Tenant Scope**: This IS the tenant definition

The CAB aggregate represents the tenant itself and manages organizational setup, accreditation, and compliance tracking.

**Entities:**

- `ConformityAssessmentBody` *(Aggregate Root)* - **The tenant/CAB organization**
- `AccreditationScope` - Standards and sectors accredited for
- `ComplianceRequirement` - ISO 17021 clause tracking
- `InternalAudit` - Internal quality audits
- `ManagementReview` - Management system reviews
- `TenantConfiguration` - Tenant-specific settings and policies

**Value Objects:**

- `CABId` - **Primary tenant identifier** - globally unique
- `AccreditationBody` - ANAB, UKAS, etc.
- `AccreditationNumber` - Official accreditation reference
- `ComplianceStatus` - Requirements compliance tracking
- `ScopeOfAccreditation` - Authorized certification activities
- `TenantSettings` - CAB-specific business rules and configurations

**Invariants:**

- CAB must maintain valid accreditation
- All ISO 17021 requirements must be tracked
- Compliance evidence must be current
- Management reviews must occur at planned intervals
- **CAB ID serves as the primary tenant identifier for all other aggregates**

---

## Tenant-Aware Domain Services

### CertificationProcessOrchestrator

**Tenant-Scoped Service**
Coordinates the certification workflow across aggregates **within a CAB**:

- Application → Assessment → Certificate issuance
- Status synchronization between aggregates
- Business rule enforcement across boundaries
- **Ensures all operations stay within tenant boundary**

### AuditPlanningService  

**Tenant-Scoped Service**
Handles complex audit planning logic **for a specific CAB**:

- Duration calculation based on organization size
- Team competence matching to client requirements (within CAB)
- Multi-site sampling strategies
- Risk-based audit program development
- **CAB-specific audit policies and procedures**

### ComplianceMonitoringService

**Tenant-Scoped Service**
Tracks accreditation compliance **for a specific CAB**:

- ISO 17021 requirement mapping
- Evidence collection and verification
- Compliance reporting and alerts
- Audit readiness assessment
- **CAB-specific compliance requirements and evidence**

### TenantManagementService

**Platform-Level Service**
Manages tenant lifecycle and isolation:

- CAB onboarding and setup
- Tenant data isolation enforcement
- Cross-tenant data access prevention
- Tenant-specific configuration management

---

## Multi-Tenant Project Structure

```
UCertify.Domain/
├── MultiTenancy/
│   ├── ITenantContext.cs
│   ├── TenantId.cs
│   ├── ITenantAware.cs
│   ├── TenantScope.cs
│   └── TenantIsolationException.cs
│
├── Aggregates/
│   ├── Applications/
│   │   ├── Application.cs                    // implements ITenantAware
│   │   ├── ApplicationReview.cs
│   │   ├── ApplicationDocument.cs
│   │   ├── ValueObjects/
│   │   │   ├── ApplicationId.cs             // tenant-scoped ID
│   │   │   ├── ApplicationStatus.cs
│   │   │   ├── CertificationScope.cs
│   │   │   ├── ContactInformation.cs
│   │   │   └── ApplicationSubmissionDetails.cs
│   │   ├── Events/
│   │   │   ├── ApplicationReceived.cs       // includes TenantId
│   │   │   ├── ApplicationApproved.cs
│   │   │   └── ApplicationRejected.cs
│   │   └── Specifications/
│   │       ├── ApplicationCompleteness.cs
│   │       ├── DuplicateApplicationCheck.cs  // tenant-scoped check
│   │       └── TenantApplicationAccess.cs
│   │
│   ├── Assessments/
│   │   ├── Assessment.cs                    // implements ITenantAware
│   │   ├── AuditPlan.cs
│   │   ├── AuditTeam.cs
│   │   ├── Finding.cs
│   │   ├── CorrectiveAction.cs
│   │   ├── AuditSession.cs
│   │   ├── ValueObjects/
│   │   │   ├── AssessmentId.cs             // tenant-scoped ID
│   │   │   ├── AssessmentType.cs
│   │   │   ├── AssessmentStatus.cs
│   │   │   ├── AuditDuration.cs
│   │   │   ├── FindingClassification.cs
│   │   │   ├── AuditEvidence.cs
│   │   │   └── AssessmentRecommendation.cs
│   │   ├── Events/
│   │   │   ├── AssessmentScheduled.cs      // includes TenantId
│   │   │   ├── FindingRaised.cs
│   │   │   ├── AssessmentCompleted.cs
│   │   │   └── RecommendationMade.cs
│   │   └── Specifications/
│   │       ├── Stage2Prerequisites.cs
│   │       ├── AuditDurationCompliance.cs
│   │       ├── FindingClassificationRules.cs
│   │       └── TenantAssessmentAccess.cs
│   │
│   ├── Clients/
│   │   ├── Client.cs                       // implements ITenantAware
│   │   ├── Site.cs
│   │   ├── CertificationHistory.cs
│   │   ├── ValueObjects/
│   │   │   ├── ClientId.cs                 // tenant-scoped ID
│   │   │   ├── LegalEntityName.cs
│   │   │   ├── Address.cs
│   │   │   ├── EmployeeCount.cs
│   │   │   ├── MultiSiteConfiguration.cs
│   │   │   └── PreviousCertificationDetails.cs
│   │   ├── Events/
│   │   │   ├── ClientRegistered.cs         // includes TenantId
│   │   │   ├── SiteAdded.cs
│   │   │   └── ClientInformationUpdated.cs
│   │   └── Specifications/
│   │       ├── ClientUniqueness.cs         // tenant-scoped uniqueness
│   │       ├── MultiSiteRequirements.cs
│   │       └── TenantClientAccess.cs
│   │
│   ├── Certificates/
│   │   ├── Certificate.cs                  // implements ITenantAware
│   │   ├── CertificateScope.cs
│   │   ├── SurveillanceSchedule.cs
│   │   ├── ValueObjects/
│   │   │   ├── CertificateId.cs           // tenant-scoped ID
│   │   │   ├── CertificateNumber.cs       // globally unique with CAB prefix
│   │   │   ├── CertificationStandard.cs
│   │   │   ├── CertificateStatus.cs
│   │   │   ├── ValidityPeriod.cs
│   │   │   └── CertificationDecision.cs
│   │   ├── Events/
│   │   │   ├── CertificateIssued.cs       // includes TenantId
│   │   │   ├── CertificateSuspended.cs
│   │   │   ├── CertificateWithdrawn.cs
│   │   │   └── SurveillanceScheduled.cs
│   │   └── Specifications/
│   │       ├── CertificateValidityRules.cs
│   │       ├── SurveillanceRequirements.cs
│   │       └── TenantCertificateAccess.cs
│   │
│   ├── Auditors/
│   │   ├── Auditor.cs                     // implements ITenantAware
│   │   ├── Competence.cs
│   │   ├── Assignment.cs
│   │   ├── ProfessionalDevelopment.cs
│   │   ├── ValueObjects/
│   │   │   ├── AuditorId.cs               // tenant-scoped ID
│   │   │   ├── AuditorRole.cs
│   │   │   ├── CompetenceMatrix.cs
│   │   │   ├── Availability.cs
│   │   │   └── ConflictOfInterest.cs
│   │   ├── Events/
│   │   │   ├── AuditorRegistered.cs       // includes TenantId
│   │   │   ├── CompetenceAdded.cs
│   │   │   ├── AuditorAssigned.cs
│   │   │   └── ConflictIdentified.cs
│   │   └── Specifications/
│   │       ├── AuditorQualifications.cs
│   │       ├── ConflictOfInterestRules.cs // tenant-scoped conflicts
│   │       ├── CompetenceRequirements.cs
│   │       └── TenantAuditorAccess.cs
│   │
│   └── CABConfiguration/
│       ├── ConformityAssessmentBody.cs    // The Tenant Entity
│       ├── AccreditationScope.cs
│       ├── ComplianceRequirement.cs
│       ├── InternalAudit.cs
│       ├── ManagementReview.cs
│       ├── TenantConfiguration.cs
│       ├── ValueObjects/
│       │   ├── CABId.cs                   // Primary Tenant ID
│       │   ├── AccreditationBody.cs
│       │   ├── AccreditationNumber.cs
│       │   ├── ComplianceStatus.cs
│       │   ├── ScopeOfAccreditation.cs
│       │   └── TenantSettings.cs
│       ├── Events/
│       │   ├── CABRegistered.cs           // Tenant creation
│       │   ├── AccreditationUpdated.cs
│       │   ├── ComplianceRequirementAdded.cs
│       │   ├── ManagementReviewCompleted.cs
│       │   └── TenantConfigurationChanged.cs
│       └── Specifications/
│           ├── AccreditationCompliance.cs
│           ├── ISO17021Requirements.cs
│           └── TenantIsolationCompliance.cs
│
├── DomainServices/
│   ├── TenantManagementService.cs         // Platform-level
│   ├── CertificationProcessOrchestrator.cs // Tenant-scoped
│   ├── AuditPlanningService.cs            // Tenant-scoped
│   ├── ComplianceMonitoringService.cs     // Tenant-scoped
│   ├── RiskAssessmentService.cs           // Tenant-scoped
│   └── NotificationService.cs             // Tenant-scoped
│
├── Common/
│   ├── ValueObjects/
│   │   ├── EntityId.cs                    // Base for tenant-scoped IDs
│   │   ├── TenantScopedId.cs             // Base class for tenant-aware IDs
│   │   ├── AuditInfo.cs
│   │   ├── DateRange.cs
│   │   ├── EmailAddress.cs
│   │   ├── PhoneNumber.cs
│   │   └── Money.cs
│   ├── Enums/
│   │   ├── AuditStage.cs
│   │   ├── WorkflowStatus.cs
│   │   ├── Standard.cs
│   │   ├── Priority.cs
│   │   └── UserRole.cs
│   ├── Exceptions/
│   │   ├── DomainException.cs
│   │   ├── BusinessRuleViolationException.cs
│   │   ├── InvalidStateTransitionException.cs
│   │   ├── ResourceNotFoundException.cs
│   │   └── TenantIsolationViolationException.cs
│   └── Interfaces/
│       ├── IAggregateRoot.cs
│       ├── IEntity.cs
│       ├── IValueObject.cs
│       ├── IDomainEvent.cs
│       ├── ISpecification.cs
│       └── ITenantAware.cs               // Marker interface for tenant-scoped entities
│
├── Events/
│   ├── Base/
│   │   ├── DomainEvent.cs                // includes TenantId
│   │   ├── TenantAwareDomainEvent.cs
│   │   └── IDomainEventHandler.cs
│   └── Integration/
│       ├── CertificationProcessEvents.cs
│       ├── ComplianceEvents.cs
│       └── TenantLifecycleEvents.cs
│
├── Repositories/
│   ├── IApplicationRepository.cs         // Tenant-scoped operations
│   ├── IAssessmentRepository.cs          // Tenant-scoped operations
│   ├── IClientRepository.cs              // Tenant-scoped operations
│   ├── ICertificateRepository.cs         // Tenant-scoped operations
│   ├── IAuditorRepository.cs             // Tenant-scoped operations
│   ├── ICABConfigurationRepository.cs    // Tenant management
│   └── ITenantRepository.cs              // Platform-level tenant operations
│
└── Specifications/
    ├── Base/
    │   ├── Specification.cs
    │   ├── CompositeSpecification.cs
    │   └── TenantAwareSpecification.cs   // Base for tenant-scoped specs
    └── Common/
        ├── UniqueIdentifierSpecification.cs  // Tenant-scoped uniqueness
        ├── DateRangeValidation.cs
        ├── StatusTransitionRules.cs
        └── TenantAccessSpecification.cs
```

---

## Multi-Tenant Design Patterns

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
    
    // Ensures uniqueness within tenant scope
}

// Base class for tenant-aware domain events
public abstract class TenantAwareDomainEvent : DomainEvent
{
    public CABId TenantId { get; private set; }
}
```

### 2. Tenant Context Injection

```csharp
public interface ITenantContext
{
    CABId CurrentTenantId { get; }
    bool IsSystemContext { get; } // For platform-level operations
}

// Domain services are tenant-scoped
public class AuditPlanningService
{
    private readonly ITenantContext _tenantContext;
    
    public AuditPlan CreateAuditPlan(Assessment assessment)
    {
        // Automatically scoped to current tenant
        if (assessment.TenantId != _tenantContext.CurrentTenantId)
            throw new TenantIsolationViolationException();
            
        // Business logic...
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
    
    // Tenant isolation enforced at repository level
}
```

---

## Key Multi-Tenant Design Considerations

### 1. Data Isolation

- **Logical Separation**: All data queries include tenant filter
- **Aggregate Boundaries**: Tenant isolation enforced at aggregate root level
- **Cross-Tenant Prevention**: Domain services prevent cross-tenant data access
- **Audit Trail**: All operations logged with tenant context

### 2. Business Rules

- **Tenant-Specific Rules**: Some business rules vary by CAB (policies, procedures)
- **Global Rules**: ISO 17021 requirements apply to all tenants
- **Configuration**: Tenant-specific settings for customizable rules
- **Compliance**: Each CAB maintains separate compliance status

### 3. Certificate Numbering

- **Global Uniqueness**: Certificate numbers include CAB prefix (e.g., "ABC-2025-001")
- **Public Registry**: Certificates may be publicly searchable across all CABs
- **Brand Identity**: Each CAB maintains their own certificate branding

### 4. Security & Access

- **User Context**: Users belong to specific CAB tenants
- **Role-Based Access**: Permissions scoped within tenant boundaries
- **Data Encryption**: Tenant data encrypted with tenant-specific keys
- **Backup/Recovery**: Tenant-specific backup and recovery procedures

---

## Future Considerations

### Phase 2 Extensions

- **Cross-Tenant Analytics**: Anonymous benchmarking across CABs
- **Shared Resources**: Common libraries or templates across tenants
- **Tenant Hierarchies**: Support for CAB subsidiaries or partnerships
- **Multi-Tenant Reporting**: Platform-level insights and analytics

### Technical Evolution

- **Tenant Sharding**: Physical data separation for large tenants
- **Regional Compliance**: Tenant data residency requirements
- **Tenant-Specific Integrations**: CAB-specific external system connections
- **White-Label Solutions**: Tenant-branded user interfaces

---

*Document Version: 2.0*  
*Last Updated: 2025-01-22*  
*Review Frequency: As domain understanding evolves*

**Note**: Multi-tenancy is a core architectural concern that affects every aspect of the domain model. This tenant-aware design ensures proper data isolation while maintaining clean domain boundaries and business rule enforcement.
