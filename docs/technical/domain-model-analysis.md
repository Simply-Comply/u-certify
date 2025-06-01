# U-Certify Domain Model Analysis

## Overview

This document analyzes the business requirements from the U-Certify platform and defines the domain model including entities, value objects, aggregates, and the recommended project structure for the `UCertify.Domain` project.

**Domain**: Conformity Assessment Body (CAB) Management System  
**Standards Focus**: ISO/IEC 17021-1:2015 - Management System Certification Bodies  
**Business Context**: Certification lifecycle management from application to certificate maintenance  
**Architecture Note**: This is a multi-tenant platform - see `domain-multi-tenancy.md` for tenant-specific design patterns

---

## Domain Boundaries

The U-Certify platform operates within three main bounded contexts:

1. **Certification Management**: Core business process from application to certificate issuance
2. **Compliance Management**: Accreditation requirements tracking and evidence management  
3. **Resource Management**: Auditor competencies, scheduling, and CAB operations

---

## Aggregates and Aggregate Roots

### 1. Application Aggregate
**Aggregate Root**: `Application`

The Application aggregate manages the initial certification request lifecycle, from submission through approval/rejection.

**Entities:**
- `Application` *(Aggregate Root)* - Primary certification request
- `ApplicationReview` - Review process and decisions
- `ApplicationDocument` - Supporting documentation

**Value Objects:**
- `ApplicationId` - Unique identifier (APP-YYYY-NNNNN format)
- `ApplicationStatus` - Workflow state (Received, Under Review, Approved, etc.)
- `CertificationScope` - Description of activities to be certified
- `ContactInformation` - Client contact details
- `ApplicationSubmissionDetails` - Channel, timestamp, source

**Key Business Rules:**
- Application must have unique identifier once created
- Status transitions must follow defined workflow
- Mandatory fields must be complete before proceeding
- Scope description must be substantive (>50 characters)
- Applications are tenant-scoped to the CAB

---

### 2. Assessment Aggregate  
**Aggregate Root**: `Assessment`

The Assessment aggregate encapsulates the entire audit process including planning, execution, and findings.

**Entities:**
- `Assessment` *(Aggregate Root)* - Main audit/assessment process
- `AuditPlan` - Detailed audit planning and schedule
- `AuditTeam` - Team composition and roles
- `Finding` - Individual audit findings and nonconformities
- `CorrectiveAction` - Client responses to findings
- `AuditSession` - Daily audit activities and evidence collection

**Value Objects:**
- `AssessmentId` - Unique assessment identifier
- `AssessmentType` - Stage 1, Stage 2, Surveillance, Recertification
- `AssessmentStatus` - Planned, In Progress, Completed, Report Issued
- `AuditDuration` - Time allocation based on organization size
- `FindingClassification` - Major NC, Minor NC, Observation, OFI
- `AuditEvidence` - Objective evidence supporting findings
- `AssessmentRecommendation` - Recommend/Conditional/Do Not Recommend

**Key Business Rules:**
- Stage 2 cannot start without completed Stage 1
- Assessment duration must meet ISO 17021 minimums
- All findings must have supporting objective evidence
- Lead auditor must make clear recommendation
- Assessment team members must be competent for the standards being audited

---

### 3. Client Aggregate
**Aggregate Root**: `Client`

The Client aggregate manages organization information, sites, and certification history.

**Entities:**
- `Client` *(Aggregate Root)* - Client organization
- `Site` - Physical locations within certification scope
- `CertificationHistory` - Previous and current certifications

**Value Objects:**
- `ClientId` - Unique client identifier
- `LegalEntityName` - Official organization name
- `Address` - Physical address details
- `EmployeeCount` - FTE count for audit duration calculation
- `MultiSiteConfiguration` - Central office designation and site relationships
- `PreviousCertificationDetails` - Transfer information from other CABs

**Key Business Rules:**
- Client must have at least one site
- Multi-site clients must designate central office
- Legal entity name must be unique within CAB
- Employee count must be greater than zero
- Certification transfers must include proper documentation

---

### 4. Certificate Aggregate
**Aggregate Root**: `Certificate`

The Certificate aggregate manages the certification lifecycle and maintenance.

**Entities:**
- `Certificate` *(Aggregate Root)* - Issued certification document
- `CertificateScope` - Detailed scope of certification
- `SurveillanceSchedule` - Ongoing surveillance audit planning

**Value Objects:**
- `CertificateId` - Unique certificate identifier
- `CertificateNumber` - Public certificate reference (globally unique)
- `CertificationStandard` - ISO 9001, 14001, 45001, etc.
- `CertificateStatus` - Active, Suspended, Withdrawn, Expired
- `ValidityPeriod` - Issue date, expiry date, 3-year cycle
- `CertificationDecision` - Grant, Refuse, Conditional grant

**Key Business Rules:**
- Certificate validity period must be exactly 3 years
- Certificate number must be globally unique
- Status transitions must follow certification rules
- Suspension requires documented justification
- Surveillance audits must occur within 12 months

---

### 5. Auditor Aggregate
**Aggregate Root**: `Auditor`

The Auditor aggregate manages auditor information, competencies, and availability.

**Entities:**
- `Auditor` *(Aggregate Root)* - Individual auditor
- `Competence` - Standard-specific qualifications
- `Assignment` - Audit assignments and roles
- `ProfessionalDevelopment` - CPD tracking

**Value Objects:**
- `AuditorId` - Unique auditor identifier
- `AuditorRole` - Lead Auditor, Auditor, Technical Expert
- `CompetenceMatrix` - Standards and sectors qualified for
- `Availability` - Schedule and capacity
- `ConflictOfInterest` - Client relationship restrictions

**Key Business Rules:**
- Lead auditors must have appropriate qualifications
- Conflict of interest must be checked for all assignments
- CPD requirements must be maintained annually
- Competence must be current for assigned standards
- Auditors cannot audit their own work or former employers

---

### 6. CAB Configuration Aggregate
**Aggregate Root**: `ConformityAssessmentBody`

The CAB aggregate manages organizational setup, accreditation, and compliance tracking.

**Entities:**
- `ConformityAssessmentBody` *(Aggregate Root)* - The certification body
- `AccreditationScope` - Standards and sectors accredited for
- `ComplianceRequirement` - ISO 17021 clause tracking
- `InternalAudit` - Internal quality audits
- `ManagementReview` - Management system reviews

**Value Objects:**
- `CABId` - Unique CAB identifier (serves as tenant ID)
- `AccreditationBody` - ANAB, UKAS, etc.
- `AccreditationNumber` - Official accreditation reference
- `ComplianceStatus` - Requirements compliance tracking
- `ScopeOfAccreditation` - Authorized certification activities

**Key Business Rules:**
- CAB must maintain valid accreditation
- All ISO 17021 requirements must be tracked
- Compliance evidence must be current
- Management reviews must occur at planned intervals
- Internal audits must cover all processes annually

---

## Domain Services

### CertificationProcessOrchestrator
Coordinates the certification workflow across aggregates:
- Application → Assessment → Certificate issuance
- Status synchronization between aggregates
- Business rule enforcement across boundaries
- Workflow state management

### AuditPlanningService  
Handles complex audit planning logic:
- Duration calculation based on organization size (ISO 17021 Annex B)
- Team competence matching to client requirements
- Multi-site sampling strategies
- Risk-based audit program development

### ComplianceMonitoringService
Tracks accreditation compliance:
- ISO 17021 requirement mapping
- Evidence collection and verification
- Compliance reporting and alerts
- Audit readiness assessment

---

## Recommended Project Structure

```
UCertify.Domain/
├── Aggregates/
│   ├── Applications/
│   │   ├── Application.cs
│   │   ├── ApplicationReview.cs
│   │   ├── ApplicationDocument.cs
│   │   ├── ValueObjects/
│   │   │   ├── ApplicationId.cs
│   │   │   ├── ApplicationStatus.cs
│   │   │   ├── CertificationScope.cs
│   │   │   ├── ContactInformation.cs
│   │   │   └── ApplicationSubmissionDetails.cs
│   │   ├── Events/
│   │   │   ├── ApplicationReceived.cs
│   │   │   ├── ApplicationApproved.cs
│   │   │   └── ApplicationRejected.cs
│   │   └── Specifications/
│   │       ├── ApplicationCompleteness.cs
│   │       └── DuplicateApplicationCheck.cs
│   │
│   ├── Assessments/
│   │   ├── Assessment.cs
│   │   ├── AuditPlan.cs
│   │   ├── AuditTeam.cs
│   │   ├── Finding.cs
│   │   ├── CorrectiveAction.cs
│   │   ├── AuditSession.cs
│   │   ├── ValueObjects/
│   │   │   ├── AssessmentId.cs
│   │   │   ├── AssessmentType.cs
│   │   │   ├── AssessmentStatus.cs
│   │   │   ├── AuditDuration.cs
│   │   │   ├── FindingClassification.cs
│   │   │   ├── AuditEvidence.cs
│   │   │   └── AssessmentRecommendation.cs
│   │   ├── Events/
│   │   │   ├── AssessmentScheduled.cs
│   │   │   ├── FindingRaised.cs
│   │   │   ├── AssessmentCompleted.cs
│   │   │   └── RecommendationMade.cs
│   │   └── Specifications/
│   │       ├── Stage2Prerequisites.cs
│   │       ├── AuditDurationCompliance.cs
│   │       └── FindingClassificationRules.cs
│   │
│   ├── Clients/
│   │   ├── Client.cs
│   │   ├── Site.cs
│   │   ├── CertificationHistory.cs
│   │   ├── ValueObjects/
│   │   │   ├── ClientId.cs
│   │   │   ├── LegalEntityName.cs
│   │   │   ├── Address.cs
│   │   │   ├── EmployeeCount.cs
│   │   │   ├── MultiSiteConfiguration.cs
│   │   │   └── PreviousCertificationDetails.cs
│   │   ├── Events/
│   │   │   ├── ClientRegistered.cs
│   │   │   ├── SiteAdded.cs
│   │   │   └── ClientInformationUpdated.cs
│   │   └── Specifications/
│   │       ├── ClientUniqueness.cs
│   │       └── MultiSiteRequirements.cs
│   │
│   ├── Certificates/
│   │   ├── Certificate.cs
│   │   ├── CertificateScope.cs
│   │   ├── SurveillanceSchedule.cs
│   │   ├── ValueObjects/
│   │   │   ├── CertificateId.cs
│   │   │   ├── CertificateNumber.cs
│   │   │   ├── CertificationStandard.cs
│   │   │   ├── CertificateStatus.cs
│   │   │   ├── ValidityPeriod.cs
│   │   │   └── CertificationDecision.cs
│   │   ├── Events/
│   │   │   ├── CertificateIssued.cs
│   │   │   ├── CertificateSuspended.cs
│   │   │   ├── CertificateWithdrawn.cs
│   │   │   └── SurveillanceScheduled.cs
│   │   └── Specifications/
│   │       ├── CertificateValidityRules.cs
│   │       └── SurveillanceRequirements.cs
│   │
│   ├── Auditors/
│   │   ├── Auditor.cs
│   │   ├── Competence.cs
│   │   ├── Assignment.cs
│   │   ├── ProfessionalDevelopment.cs
│   │   ├── ValueObjects/
│   │   │   ├── AuditorId.cs
│   │   │   ├── AuditorRole.cs
│   │   │   ├── CompetenceMatrix.cs
│   │   │   ├── Availability.cs
│   │   │   └── ConflictOfInterest.cs
│   │   ├── Events/
│   │   │   ├── AuditorRegistered.cs
│   │   │   ├── CompetenceAdded.cs
│   │   │   ├── AuditorAssigned.cs
│   │   │   └── ConflictIdentified.cs
│   │   └── Specifications/
│   │       ├── AuditorQualifications.cs
│   │       ├── ConflictOfInterestRules.cs
│   │       └── CompetenceRequirements.cs
│   │
│   └── CABConfiguration/
│       ├── ConformityAssessmentBody.cs
│       ├── AccreditationScope.cs
│       ├── ComplianceRequirement.cs
│       ├── InternalAudit.cs
│       ├── ManagementReview.cs
│       ├── ValueObjects/
│       │   ├── CABId.cs
│       │   ├── AccreditationBody.cs
│       │   ├── AccreditationNumber.cs
│       │   ├── ComplianceStatus.cs
│       │   └── ScopeOfAccreditation.cs
│       ├── Events/
│       │   ├── CABRegistered.cs
│       │   ├── AccreditationUpdated.cs
│       │   ├── ComplianceRequirementAdded.cs
│       │   └── ManagementReviewCompleted.cs
│       └── Specifications/
│           ├── AccreditationCompliance.cs
│           └── ISO17021Requirements.cs
│
├── DomainServices/
│   ├── CertificationProcessOrchestrator.cs
│   ├── AuditPlanningService.cs
│   ├── ComplianceMonitoringService.cs
│   ├── RiskAssessmentService.cs
│   └── NotificationService.cs
│
├── SharedKernel/
│   ├── ValueObjects/
│   │   ├── EntityId.cs
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
│   │   └── ResourceNotFoundException.cs
│   └── Interfaces/
│       ├── IAggregateRoot.cs
│       ├── IEntity.cs
│       ├── IValueObject.cs
│       ├── IDomainEvent.cs
│       └── ISpecification.cs
│
├── Events/
│   ├── Base/
│   │   ├── DomainEvent.cs
│   │   └── IDomainEventHandler.cs
│   └── Integration/
│       ├── CertificationProcessEvents.cs
│       └── ComplianceEvents.cs
│
├── Repositories/
│   ├── IApplicationRepository.cs
│   ├── IAssessmentRepository.cs
│   ├── IClientRepository.cs
│   ├── ICertificateRepository.cs
│   ├── IAuditorRepository.cs
│   └── ICABConfigurationRepository.cs
│
└── Specifications/
    ├── Base/
    │   ├── Specification.cs
    │   └── CompositeSpecification.cs
    └── Common/
        ├── UniqueIdentifierSpecification.cs
        ├── DateRangeValidation.cs
        └── StatusTransitionRules.cs
```

---

## Key Design Considerations

### 1. Aggregate Boundaries
- **Transaction Boundaries**: Each aggregate ensures consistency within its boundary
- **Business Process Alignment**: Aggregates map to natural business workflows  
- **Size Management**: Aggregates kept focused to avoid complexity
- **Event-Driven Communication**: Cross-aggregate communication via domain events

### 2. Value Object Identification
- **Immutability**: All value objects are immutable once created
- **Self-Validation**: Value objects validate their own business rules
- **Equality by Value**: Comparison based on contained values, not identity
- **Meaningful Abstractions**: Each value object represents a business concept

### 3. Domain Services
- **Stateless Operations**: Services contain no state, only behavior
- **Cross-Aggregate Logic**: Handle operations spanning multiple aggregates
- **Complex Business Rules**: Encapsulate complex domain logic
- **Infrastructure Independence**: Pure domain logic without technical concerns

### 4. Business Rules Enforcement
- **Aggregate Invariants**: Core business rules enforced within aggregates
- **Specifications**: Complex business rules encapsulated in specification objects
- **Domain Events**: Communicate rule violations and state changes
- **Consistency Boundaries**: Strong consistency within aggregates, eventual consistency between

---

## Core Business Processes

### 1. Certification Workflow
```
Application → Review → Contract → Stage 1 → Stage 2 → Decision → Certificate
```

### 2. Assessment Types
- **Stage 1**: Readiness assessment and documentation review
- **Stage 2**: Full conformity assessment and implementation verification
- **Surveillance**: Annual maintenance audits
- **Recertification**: 3-year cycle renewal assessments

### 3. Finding Management
- **Major Nonconformity**: Significant failure requiring correction before certification
- **Minor Nonconformity**: Isolated failure requiring correction within timeframe
- **Observation**: Potential concern noted for improvement
- **Opportunity for Improvement**: Suggestion beyond minimum compliance

---

## ISO 17021 Compliance Requirements

### Key Standards Alignment
- **Clause 9.1**: Application process requirements
- **Clause 9.2**: Audit planning and resource allocation
- **Clause 9.3**: Assessment execution requirements
- **Clause 9.4**: Decision-making process
- **Clause 9.5**: Certificate issuance and maintenance

### Audit Duration Requirements (Annex B)
- Based on organization size (employee count)
- Complexity factors (multiple sites, integrated standards)
- Minimum durations must be met
- Additional time for high-risk sectors

---

## Future Considerations

### Phase 2 Extensions
- **Multi-Standard Support**: Additional ISO standards (17025, 17020)
- **Advanced Analytics**: KPI calculation and trend analysis
- **Financial Integration**: Cost tracking and invoicing
- **External Integrations**: Accreditation body systems

### Technical Evolution
- **Event Sourcing**: Consider for comprehensive audit trail requirements
- **CQRS Implementation**: Separate read/write models for performance
- **Microservices**: Potential bounded context separation
- **API Design**: External system integration points

---

*Document Version: 1.0*  
*Last Updated: 2025-01-22*  
*Review Frequency: As domain understanding evolves*

**Note**: This domain model serves as the foundation for the U-Certify platform development. For multi-tenancy patterns and tenant-specific considerations, refer to the companion document `domain-multi-tenancy.md`. 