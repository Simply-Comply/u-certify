# Application Aggregate Invariants

## Overview

This document defines the **invariants** for the Application aggregate in the U-Certify domain model. Invariants are business rules that must **always** be true for the Application aggregate to be in a valid state. These rules are enforced within the aggregate boundary and ensure data consistency and business rule compliance according to ISO/IEC 17021-1:2015 requirements.

**Domain Context**: Conformity Assessment Body (CAB) Management System  
**Aggregate**: Application  
**Tenant Scope**: CAB-specific (each Application belongs to exactly one CAB tenant)

---

## Core Aggregate Invariants

### INV-APP-001: Tenant Isolation
**Invariant**: Every Application MUST belong to exactly one CAB tenant
- **Condition**: `Application.TenantId != null && Application.TenantId.IsValid()`
- **Enforcement**: Set during creation, immutable thereafter
- **Violation**: Throws `TenantIsolationViolationException`
- **Rationale**: Multi-tenant data isolation requirement

### INV-APP-002: Unique Identifier
**Invariant**: Application MUST have a unique identifier within the CAB tenant
- **Condition**: `ApplicationId` follows format `APP-YYYY-NNNNN` and is unique within tenant scope
- **Format Validation**: `^APP-\d{4}-\d{5}$`
- **Enforcement**: System-generated, immutable after creation
- **Violation**: Throws `DuplicateApplicationIdException`
- **Rationale**: Essential for tracking throughout certification lifecycle (BR-AR-003)

### INV-APP-003: Mandatory Field Completeness
**Invariant**: Application MUST contain all mandatory information before proceeding to review
- **Required Fields**:
  - `LegalEntityName` (not null, not empty, length >= 2)
  - `PrimaryContact.Name` (not null, not empty)
  - `PrimaryContact.Email` (valid email format)
  - `PrimaryContact.PhoneNumber` (valid phone format)
  - `PhysicalAddress` (complete address with country)
  - `RequestedStandards` (at least one valid standard)
  - `CertificationScope.Description` (length >= 50 characters)
  - `EmployeeCount.TotalFTE` (> 0)
- **Enforcement**: Validation before status change to "Under Review"
- **Violation**: Throws `IncompleteApplicationException`
- **Rationale**: ISO 17021 Clause 9.1.1 requirements (BR-AR-002)

### INV-APP-004: Status Workflow Integrity
**Invariant**: Application status transitions MUST follow defined workflow
- **Valid Transitions**:
  - `null` → `Received` (creation)
  - `Received` → `Under Review`
  - `Received` → `Withdrawn`
  - `Under Review` → `Information Requested`
  - `Under Review` → `Approved`
  - `Under Review` → `Rejected`
  - `Under Review` → `Withdrawn`
  - `Information Requested` → `Under Review`
  - `Information Requested` → `Withdrawn`
- **Enforcement**: State machine validation in `ChangeStatus()` method
- **Violation**: Throws `InvalidStateTransitionException`
- **Rationale**: Ensures proper workflow control (BR-AR-008)

### INV-APP-005: Certification Scope Validity
**Invariant**: Certification scope description MUST be substantive and meaningful
- **Conditions**:
  - `CertificationScope.Description.Length >= 50`
  - `CertificationScope.Description` not generic (no "all activities", "everything")
  - Must describe specific business activities
  - Language: English only (MVP constraint)
- **Enforcement**: Content validation with prohibited phrase detection
- **Violation**: Throws `InvalidCertificationScopeException`
- **Rationale**: Clear scope definition critical for audit planning (BR-AR-011)

### INV-APP-006: Employee Count Validity
**Invariant**: Employee numbers MUST be provided and valid for audit duration calculation
- **Conditions**:
  - `EmployeeCount.FullTimeEquivalent > 0`
  - `EmployeeCount.FullTime >= 0`
  - `EmployeeCount.PartTime >= 0`
  - `EmployeeCount.Contractors >= 0`
  - `EmployeeCount.TotalFTE = FullTime + (PartTime * 0.5) + Contractors`
- **Enforcement**: Calculation validation during creation/update
- **Violation**: Throws `InvalidEmployeeCountException`
- **Rationale**: ISO 17021 Annex B audit duration requirements (BR-AR-012)

### INV-APP-007: Multi-Site Central Office Designation
**Invariant**: Multi-site applications MUST designate exactly one central office
- **Condition**: If `Sites.Count > 1` then exactly one site MUST have `IsCentralOffice = true`
- **Additional Rule**: Single-site applications cannot designate central office
- **Enforcement**: Validation when adding/removing sites
- **Violation**: Throws `InvalidMultiSiteConfigurationException`
- **Rationale**: ISO 17021 Annex A central function requirement (BR-AR-006)

### INV-APP-008: Standard Combination Validity
**Invariant**: Requested certification standards MUST be valid combinations
- **Allowed Combinations**:
  - Single standard: ISO 9001, ISO 14001, or ISO 45001
  - Dual standards: 9001+14001, 9001+45001, 14001+45001
  - Triple standard: 9001+14001+45001
- **Prohibited**: Empty standards list
- **Enforcement**: Validation during standard selection
- **Violation**: Throws `InvalidStandardCombinationException`
- **Rationale**: Enables integrated audits while maintaining integrity (BR-AR-007)

### INV-APP-009: Receipt Timestamp Immutability
**Invariant**: Application receipt timestamp MUST be immutable once set
- **Conditions**:
  - `ReceiptTimestamp` set only once during creation
  - Precision: UTC timestamp with local timezone stored
  - Cannot be null for applications in "Received" status or later
- **Enforcement**: Property setter restriction after initial assignment
- **Violation**: Throws `ImmutableFieldViolationException`
- **Rationale**: Establishes official receipt date for SLA tracking (BR-AR-005)

### INV-APP-010: Confidentiality Classification
**Invariant**: All applications MUST maintain confidentiality classification
- **Condition**: `ConfidentialityLevel = "Confidential - Client Data"`
- **Immutability**: Classification cannot be changed (always confidential)
- **Access Control**: Must respect role-based access restrictions
- **Enforcement**: Set during creation, validation on access
- **Violation**: Throws `ConfidentialityViolationException`
- **Rationale**: ISO 17021 Clause 8.4 confidentiality requirements (BR-AR-009)

---

## Entity-Specific Invariants

### Application Review Invariants

#### INV-REV-001: Review Assignment
**Invariant**: ApplicationReview MUST be assigned to qualified reviewer
- **Condition**: `ReviewerId` references valid CAB staff member with appropriate role
- **Tenant Scope**: Reviewer must belong to same CAB tenant
- **Enforcement**: Validation during review assignment
- **Violation**: Throws `InvalidReviewerAssignmentException`

#### INV-REV-002: Review Completeness
**Invariant**: ApplicationReview MUST be complete before status change to approved/rejected
- **Required Fields**:
  - `TechnicalReview.IsComplete = true`
  - `CommercialReview.IsComplete = true`
  - `Recommendation` (Approve/Reject with justification)
- **Enforcement**: Validation before final status transition
- **Violation**: Throws `IncompleteReviewException`

### Application Document Invariants

#### INV-DOC-001: Document Integrity
**Invariant**: ApplicationDocuments MUST maintain file integrity and validity
- **Conditions**:
  - File size <= 10MB
  - Allowed formats: PDF, DOC, DOCX, XLS, XLSX
  - Virus scan passed
  - Document type matches content
- **Enforcement**: Validation during upload
- **Violation**: Throws `InvalidDocumentException`

#### INV-DOC-002: Document Retention
**Invariant**: ApplicationDocuments MUST be retained for minimum period
- **Retention Period**: 9 years (3 certification cycles)
- **Condition**: Documents cannot be deleted before retention expiry
- **Enforcement**: Soft delete with retention check
- **Violation**: Throws `PrematureDocumentDeletionException`

---

## Cross-Aggregate Invariants

### INV-APP-011: Client Uniqueness Within Tenant
**Invariant**: Legal entity name MUST be unique within CAB tenant scope
- **Condition**: No other application with same `LegalEntityName` in same tenant
- **Case Sensitivity**: Case-insensitive comparison
- **Normalization**: Trim whitespace, standardize punctuation
- **Enforcement**: Validation during creation and name updates
- **Violation**: Throws `DuplicateClientNameException`
- **Rationale**: Prevents processing conflicts (BR-AR-004)

### INV-APP-012: Transfer Certificate Validation
**Invariant**: Certificate transfer information MUST be valid if provided
- **Conditions**:
  - If `PreviousCertification.IsTransfer = true`:
    - `PreviousCAB` must be valid organization
    - `CertificateNumber` must be provided
    - `ExpiryDate` must be in future
    - `ReasonForChange` must be documented
- **Enforcement**: Validation when transfer flag is set
- **Violation**: Throws `InvalidTransferInformationException`
- **Rationale**: Transfer rules per IAF MD 2 (BR-AR-013)

---

## Value Object Invariants

### Application ID Invariants

#### INV-APPID-001: Format Compliance
**Invariant**: ApplicationId MUST follow exact format specification
- **Format**: `APP-YYYY-NNNNN` where YYYY is year, NNNNN is zero-padded sequence
- **Regex**: `^APP-\d{4}-\d{5}$`
- **Year**: Must match application creation year
- **Sequence**: Must be unique within tenant and year
- **Enforcement**: Creation validation with format check
- **Violation**: Throws `InvalidApplicationIdFormatException`

### Certification Scope Invariants

#### INV-SCOPE-001: Scope Description Quality
**Invariant**: CertificationScope MUST contain meaningful business description
- **Minimum Length**: 50 characters
- **Maximum Length**: 2000 characters
- **Prohibited Phrases**: "all activities", "everything", "general business"
- **Required Elements**: Specific business activities or processes
- **Language**: English only (MVP)
- **Enforcement**: Content analysis during creation/update
- **Violation**: Throws `InvalidScopeDescriptionException`

### Contact Information Invariants

#### INV-CONTACT-001: Contact Completeness
**Invariant**: ContactInformation MUST be complete and valid
- **Required Fields**:
  - `Name` (2-100 characters)
  - `Email` (valid format, domain verification)
  - `PhoneNumber` (valid international format)
  - `JobTitle` (for primary contact)
- **Optional**: Secondary contact with same validation rules
- **Enforcement**: Field validation during creation/update
- **Violation**: Throws `InvalidContactInformationException`

---

## Temporal Invariants

### INV-APP-013: Application Lifecycle Timing
**Invariant**: Application MUST progress through workflow within defined timeframes
- **SLA Constraints**:
  - Receipt acknowledgment: <= 5 minutes
  - Initial review start: <= 2 business days
  - Review completion: <= 10 business days
- **Escalation**: Automatic escalation if SLA violated
- **Enforcement**: Workflow engine monitoring
- **Violation**: Triggers `SLAViolationEvent` (not exception)

### INV-APP-014: Data Freshness
**Invariant**: Application data MUST be updated if stale during review
- **Staleness Threshold**: 180 days from last update
- **Affected Fields**: Contact information, employee count, scope
- **Action**: Flag for data refresh before proceeding
- **Enforcement**: Age calculation during status transitions
- **Violation**: Triggers `DataFreshnessWarningEvent`

---

## Implementation Guidelines

### Invariant Enforcement Patterns

1. **Constructor Invariants**: Enforced during entity creation
2. **Method Invariants**: Validated before state changes
3. **Property Invariants**: Enforced in property setters
4. **Cross-Entity Invariants**: Validated in domain services

### Exception Hierarchy

```
DomainException
├── BusinessRuleViolationException
│   ├── TenantIsolationViolationException
│   ├── InvalidStateTransitionException
│   ├── IncompleteApplicationException
│   ├── InvalidCertificationScopeException
│   ├── InvalidEmployeeCountException
│   ├── InvalidMultiSiteConfigurationException
│   ├── InvalidStandardCombinationException
│   └── DuplicateClientNameException
├── DataIntegrityException
│   ├── DuplicateApplicationIdException
│   ├── ImmutableFieldViolationException
│   ├── InvalidDocumentException
│   └── InvalidTransferInformationException
└── SecurityException
    ├── ConfidentialityViolationException
    └── InvalidReviewerAssignmentException
```

### Testing Strategy

1. **Unit Tests**: Each invariant should have comprehensive test coverage
2. **Property-Based Testing**: Use property-based tests for value object invariants
3. **State Machine Testing**: Verify all valid and invalid state transitions
4. **Cross-Aggregate Testing**: Validate tenant isolation and uniqueness constraints

---

## Compliance Mapping

| Invariant | ISO 17021-1 Clause | IAF Document | Business Rule |
|-----------|-------------------|--------------|---------------|
| INV-APP-003 | 9.1.1 | - | BR-AR-002 |
| INV-APP-002 | - | - | BR-AR-003 |
| INV-APP-005 | 9.1.1 | - | BR-AR-011 |
| INV-APP-006 | Annex B | - | BR-AR-012 |
| INV-APP-007 | Annex A | - | BR-AR-006 |
| INV-APP-010 | 8.4 | - | BR-AR-009 |
| INV-APP-012 | - | IAF MD 2 | BR-AR-013 |

---

*Document Version: 1.0*  
*Last Updated: 2025-01-22*  
*Review Frequency: With each domain model update*

**Note**: These invariants represent the core business rules that must be maintained at all times within the Application aggregate. Any violation of these invariants indicates a system error or attempted invalid operation that must be prevented. 