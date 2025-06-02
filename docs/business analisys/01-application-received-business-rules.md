# Business Rules - Application Received Stage

## Overview

The Application Received stage initiates the client certification process. This stage captures initial client information, validates basic requirements, and triggers the formal review process.

## Domain Context

- **Stage Type**: Initial Entry Point
- **Actors**: Client (External), CAB Administrative Staff, System
- **ISO 17021 Reference**: Clause 9.1.1 - Application for certification

## Business Rules

### BR-AR-001: Application Submission Channel

**Rule**: Applications SHALL be accepted through approved channels only

- **Allowed Channels**:
  - Web portal submission
  - Email with structured form attachment
  - Manual entry by CAB staff (for paper/fax submissions)
- **Constraint**: Each application MUST have a documented submission source
- **Rationale**: Ensures traceability and compliance with ISO 17021 requirements

### BR-AR-002: Mandatory Application Information

**Rule**: An application MUST contain minimum required information to be accepted

- **Required Fields**:
  - Legal entity name
  - Primary contact information (name, email, phone)
  - Physical address(es) of site(s) to be certified
  - Requested certification standard(s) (ISO 9001, 14001, or 45001)
  - Scope of certification (description of activities)
  - Number of employees (for audit duration calculation)
  - Preferred certification timeline
- **Validation**: System SHALL reject incomplete applications
- **Rationale**: ISO 17021 Clause 9.1.1 requires sufficient information for planning

### BR-AR-003: Application Unique Identifier

**Rule**: Each application MUST be assigned a unique identifier upon receipt

- **Format**: APP-YYYY-NNNNN (e.g., APP-2025-00001)
- **Constraint**: Identifier MUST be immutable once assigned
- **Generation**: System-generated, sequential within year
- **Rationale**: Enables tracking throughout certification lifecycle

### BR-AR-004: Duplicate Application Detection

**Rule**: System SHALL detect potential duplicate applications

- **Detection Criteria**:
  - Same legal entity name AND
  - Same certification standard AND
  - Application date within 90 days
- **Action**: Flag for manual review, do not auto-reject
- **Rationale**: Prevents processing conflicts and resource waste

### BR-AR-005: Application Timestamp

**Rule**: Application receipt MUST be timestamped with server time

- **Precision**: Date and time to seconds (YYYY-MM-DD HH:MM:SS)
- **Timezone**: UTC with local timezone stored separately
- **Immutability**: Timestamp cannot be modified after creation
- **Rationale**: Establishes official receipt date for SLA tracking

### BR-AR-006: Multi-Site Application Handling

**Rule**: Applications for multiple sites MUST identify the central function

- **Requirement**: Designate one site as "Central Office"
- **Validation**: At least one site must be marked as central
- **Constraint**: Central office cannot be changed without new application
- **Rationale**: ISO 17021 Annex A requires central function identification

### BR-AR-007: Multi-Standard Application

**Rule**: Single application MAY request multiple certification standards

- **Allowed Combinations**:
  - ISO 9001 + ISO 14001
  - ISO 9001 + ISO 45001
  - ISO 14001 + ISO 45001
  - All three standards
- **Constraint**: Each standard requires separate scope statement
- **Rationale**: Enables integrated audits while maintaining standard integrity

### BR-AR-008: Application Status Initialization

**Rule**: New applications MUST be initialized with "Received" status

- **Initial Status**: "Received"
- **Allowed Transitions**: "Received" → "Under Review" only
- **Trigger**: Status change requires assignment to reviewer
- **Rationale**: Ensures proper workflow initiation

### BR-AR-009: Confidentiality Classification

**Rule**: All application data MUST be classified as confidential

- **Default Classification**: "Confidential - Client Data"
- **Access Control**: Role-based (minimum: Administrative Staff)
- **Retention**: Minimum 3 certification cycles (9 years)
- **Rationale**: ISO 17021 Clause 8.4 confidentiality requirements

### BR-AR-010: Application Acknowledgment

**Rule**: System SHALL generate automatic acknowledgment of receipt

- **Timing**: Within 5 minutes of successful submission
- **Content**:
  - Application ID
  - Receipt timestamp
  - Next steps information
  - Expected timeline
- **Delivery**: Email to primary contact
- **Rationale**: Professional service and expectation setting

### BR-AR-011: Scope Description Validation

**Rule**: Certification scope description MUST be substantive

- **Minimum Length**: 50 characters
- **Prohibited Content**:
  - Generic descriptions (e.g., "all activities")
  - Exclusions without justification
- **Language**: English only (MVP constraint)
- **Rationale**: Clear scope definition critical for audit planning

### BR-AR-012: Employee Count Validation

**Rule**: Employee numbers MUST be provided for audit duration calculation

- **Required Breakdown**:
  - Full-time employees
  - Part-time employees (with FTE conversion)
  - Contractors within scope
  - Shift patterns (if applicable)
- **Validation**: Total must be > 0
- **Rationale**: ISO 17021 Annex B audit duration requirements

### BR-AR-013: Previous Certification History

**Rule**: Application MUST capture previous certification information

- **Required If Applicable**:
  - Previous CAB name
  - Certificate number
  - Expiry date
  - Reason for change
- **Validation**: If transfer, expiry date must be future
- **Rationale**: Transfer rules per IAF MD 2

### BR-AR-014: Application Source Attribution

**Rule**: System SHALL track application source for analytics

- **Categories**:
  - Direct (website)
  - Referral (with source)
  - Transfer from another CAB
  - Returning client
- **Requirement**: Mandatory field, no null values
- **Rationale**: Business intelligence and marketing effectiveness

### BR-AR-015: Data Completeness Check

**Rule**: System SHALL calculate application completeness percentage

- **Calculation**: (Completed fields / Total fields) × 100
- **Threshold**: 100% for mandatory fields to proceed
- **Display**: Show progress indicator during submission
- **Rationale**: Improves data quality and user experience

## State Transitions

### Valid State Transitions

- **Created** → **Received** (upon successful submission)
- **Received** → **Under Review** (upon assignment)
- **Received** → **Withdrawn** (client-initiated)

### State Invariants

- Application in "Received" state MUST have:
  - Unique identifier
  - Complete mandatory fields
  - Receipt timestamp
  - Confidentiality classification

## Integration Points

### Upstream

- Public website (application form)
- Email system (for attachments)

### Downstream

- Application Review process
- Client database
- Document management system
- Notification service

## Audit Trail Requirements

### Tracked Events

- Application created
- Fields modified (if allowed)
- Status changes
- Access log (who viewed/edited)

### Retention

- All audit logs: 9 years minimum
- Archived after 3 certification cycles

## Performance Constraints

- Application submission: < 30 seconds
- Duplicate check: < 2 seconds
- Acknowledgment email: < 5 minutes
- Field validation: Real-time (< 500ms)

## Error Handling

### BR-AR-ERR-001: Incomplete Submission

- **Condition**: Missing mandatory fields
- **Response**: Highlight missing fields, prevent submission
- **User Message**: Clear indication of required information

### BR-AR-ERR-002: System Unavailability

- **Condition**: Database or service failure
- **Response**: Queue submission, process when available
- **User Message**: "Application received, confirmation pending"

### BR-AR-ERR-003: Duplicate Detection

- **Condition**: Potential duplicate found
- **Response**: Accept but flag for review
- **User Message**: Standard acknowledgment (no duplicate mention)

## Security Considerations

- All data transmission MUST use TLS 1.2+
- File uploads scanned for malware
- Input sanitization for all text fields
- Rate limiting: Max 10 applications per IP per hour

## MVP Constraints

- English language only
- Single currency (USD)
- Three standards only (ISO 9001, 14001, 45001)
- No API integration (web form only)
- No payment processing at this stage

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*
