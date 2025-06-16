# Module Definitions

## 1. Identity Module (Platform-Level)

**Purpose:** User authentication, credentials management, and identity verification

**Scope:** Cross-tenant platform operations

**Key Aggregate Roots:**

- User - Platform users with authentication credentials
- UserProfile - User personal information and preferences
- Credentials - Authentication methods and security settings

## 2. Tenant Management Module (Platform-Level)

**Purpose:** CAB lifecycle management, subscription handling, and tenant configuration

**Scope:** Cross-tenant platform operations

**Key Aggregate Roots:**

- Tenant (CAB) - Conformity Assessment Body organization
- TenantMembership - User-tenant relationships and roles
- Subscription - Billing and feature access

## 3. Application Management Module (Business)

**Purpose:** Certification application intake and client organization management

**Scope:** Single CAB operations (tenant-scoped)

**Key Aggregate Roots:**

- Application - Certification applications from client organizations (contains ApplicationReview as entity)
- Client - Organizations seeking certification

## 4. Assessment & Audit Module (Business)

**Purpose:** Complete audit lifecycle from planning to recommendation

**Scope:** Single CAB operations (tenant-scoped)

**Key Aggregate Root:**

- **Assessment (Aggregate Root)** - Main audit/assessment process
- Contains: AuditPlan, AuditTeam, Finding, CorrectiveAction, AuditSession

## 5. Certificate Management Module (Business)

**Purpose:** Certificate issuance, lifecycle, and surveillance management

**Scope:** Single CAB operations (tenant-scoped)

**Key Aggregate Root:**

- **Certificate (Aggregate Root)** - Issued certification document
- Contains: CertificateScope, SurveillanceSchedule

## 6. Resource Management Module (Business)

**Purpose:** Auditor competence, availability, and assignment management

**Scope:** Single CAB operations (tenant-scoped)

**Key Aggregate Root:**

- **Auditor (Aggregate Root)** - Individual auditor profiles
- Contains: Competence, Assignment, ProfessionalDevelopment

## 7. Compliance & Reporting Module (Business)

**Purpose:** Cross-module compliance tracking and analytics

**Scope:** Single CAB operations with cross-module projections

**Key Aggregate Root:**

- **ComplianceTracking (Aggregate Root)** - Overall compliance status
- Contains: ComplianceRequirement, ComplianceEvidence, ComplianceAudit
- Contains: ComplianceRequirement, ComplianceEvidence, ComplianceAudit
