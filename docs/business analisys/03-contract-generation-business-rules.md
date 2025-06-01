# Business Rules - Contract Generation Stage

## Overview
The Contract Generation stage creates legally binding agreements between the CAB and client, defining certification scope, terms, conditions, and commercial arrangements. This stage translates the approved application into a formal contractual relationship.

## Domain Context
- **Stage Type**: Legal Documentation
- **Actors**: Contract Administrator, Quality Manager (approval), Client Authorized Representative, System
- **ISO 17021 Reference**: Clause 9.1.3 - Certification agreement

## Business Rules

### BR-CON-001: Contract Template Selection
**Rule**: System SHALL select appropriate contract template based on certification type
- **Template Types**:
  - Initial Certification - Single Site
  - Initial Certification - Multi-Site
  - Transfer Certification
  - Integrated Management System (multiple standards)
- **Selection Criteria**: Based on application review outcomes
- **Customization**: Predefined variable fields only
- **Rationale**: Ensures consistency and legal compliance

### BR-CON-002: Mandatory Contract Elements
**Rule**: Every contract MUST include ISO 17021 required elements
- **Required Sections**:
  - Certification scope (exact wording)
  - Applicable standard(s) and version
  - Number and location of sites
  - Audit duration (person-days)
  - Certification cycle timeline
  - CAB and client obligations
  - Terms and conditions
  - Fee structure
  - Confidentiality provisions
  - Appeals and complaints process
- **Validation**: System prevents generation without all elements
- **Rationale**: ISO 17021 Clause 9.1.3 requirements

### BR-CON-003: Scope Statement Precision
**Rule**: Certification scope MUST be precisely defined
- **Requirements**:
  - Clear description of activities included
  - Explicit statement of exclusions (if any)
  - Geographic boundaries (if applicable)
  - Product/service lines covered
- **Character Limit**: Minimum 100, Maximum 500 characters
- **Review**: Must match reviewed and approved scope
- **Rationale**: Prevents scope creep and misunderstandings

### BR-CON-004: Audit Program Definition
**Rule**: Contract MUST specify complete 3-year audit program
- **Program Elements**:
  - Stage 1 audit: Duration and tentative date
  - Stage 2 audit: Duration and tentative date
  - Surveillance 1: Timing (within 12 months of certification)
  - Surveillance 2: Timing (within 24 months of certification)
  - Recertification: Timing (before expiry)
- **Flexibility**: Dates marked as "tentative, subject to mutual agreement"
- **Rationale**: Sets clear expectations for certification cycle

### BR-CON-005: Financial Terms Specification
**Rule**: Contract MUST clearly state all financial obligations
- **Required Elements**:
  - Stage 1 audit fee
  - Stage 2 audit fee
  - Annual surveillance fees
  - Certificate issuance fee
  - Travel and expense policy
  - Payment terms (e.g., Net 30)
  - Late payment penalties
- **Currency**: USD only (MVP constraint)
- **Changes**: No fee changes within certification cycle
- **Rationale**: Transparency and dispute prevention

### BR-CON-006: Cancellation and Postponement Terms
**Rule**: Contract MUST define cancellation/postponement policies
- **Cancellation Windows**:
  - >30 days notice: No penalty
  - 15-30 days notice: 25% penalty
  - 7-14 days notice: 50% penalty
  - <7 days notice: 100% penalty
- **Postponement**: Maximum 2 times per audit, 60 days maximum delay
- **Force Majeure**: Defined list of qualifying events
- **Rationale**: Protects CAB resources while allowing flexibility

### BR-CON-007: Client Obligations
**Rule**: Contract MUST explicitly state client responsibilities
- **Key Obligations**:
  - Maintain management system compliance
  - Provide access to all locations and records
  - Make personnel available for interviews
  - Implement corrective actions within timelines
  - Notify CAB of significant changes
  - Proper use of certification marks
  - Accept witness audits by accreditation body
- **Acknowledgment**: Requires explicit client acceptance
- **Rationale**: ISO 17021 Clause 8.3 and 9.1.3 requirements

### BR-CON-008: CAB Obligations
**Rule**: Contract MUST state CAB commitments
- **Key Commitments**:
  - Conduct audits per ISO 17021
  - Maintain confidentiality
  - Provide competent audit teams
  - Issue timely reports
  - Make certification decisions impartially
  - Maintain accreditation status
  - Handle complaints professionally
- **Service Levels**: Report delivery within 10 business days
- **Rationale**: Balanced obligations and service quality

### BR-CON-009: Certification Mark Usage
**Rule**: Contract MUST define certification mark usage rules
- **Usage Rights**:
  - Granted only upon certification
  - Limited to certified scope
  - Must follow CAB brand guidelines
  - Revoked upon suspension/withdrawal
- **Restrictions**:
  - No modification of marks
  - No use on products
  - No misleading applications
- **Monitoring**: Client agrees to surveillance of mark usage
- **Rationale**: Protects certification scheme integrity

### BR-CON-010: Confidentiality Provisions
**Rule**: Contract MUST include comprehensive confidentiality terms
- **CAB Obligations**:
  - Protect all client information
  - Limited disclosure (only as required by law/accreditation)
  - Notification if disclosure required
- **Exceptions**:
  - Information already public
  - Required by accreditation body
  - Court order (with notification)
- **Duration**: Survives contract termination by 5 years
- **Rationale**: ISO 17021 Clause 8.4 requirements

### BR-CON-011: Contract Unique Identifier
**Rule**: Each contract MUST have unique identifier
- **Format**: CTR-YYYY-NNNNN-VV
  - CTR: Contract prefix
  - YYYY: Year
  - NNNNN: Sequential number
  - VV: Version (01 for initial)
- **Linking**: Must reference application ID
- **Immutability**: ID cannot change through amendments
- **Rationale**: Legal document control and traceability

### BR-CON-012: Amendment Procedures
**Rule**: Contract MUST specify amendment process
- **Amendment Triggers**:
  - Scope changes
  - Site additions/removals
  - Standard version updates
  - Legal entity changes
- **Process**: Written agreement from both parties
- **Documentation**: New version with change tracking
- **Rationale**: Maintains contract validity through changes

### BR-CON-013: Dispute Resolution
**Rule**: Contract MUST include dispute resolution mechanism
- **Escalation Path**:
  1. Direct negotiation (30 days)
  2. Mediation (if agreed)
  3. Arbitration (binding)
- **Arbitration**: Per national arbitration rules
- **Jurisdiction**: CAB's registered location
- **Rationale**: Avoids costly litigation

### BR-CON-014: Contract Approval Workflow
**Rule**: Contracts MUST follow defined approval process
- **CAB Approval**:
  - Generated by: Contract Administrator
  - Reviewed by: Quality Manager
  - Approved by: Authorized Signatory
- **Client Approval**: 
  - Authorized representative only
  - Written acceptance required
- **Timeline**: 30 days for client acceptance
- **Rationale**: Ensures proper authorization

### BR-CON-015: Electronic Signature Acceptance
**Rule**: Contract MAY be executed electronically
- **Acceptable Methods**:
  - DocuSign or equivalent
  - Email confirmation from authorized email
  - Portal acceptance with authentication
- **Requirements**:
  - Timestamp of signature
  - IP address logging
  - Identity verification
- **Legal Validity**: Equal to wet signature
- **Rationale**: Efficiency while maintaining legal validity

## State Transitions

### Valid State Transitions
- **Draft** → **Internal Review** (upon completion)
- **Internal Review** → **Approved for Sending** (QM approval)
- **Approved for Sending** → **Sent to Client** (transmitted)
- **Sent to Client** → **Signed by Client** (client acceptance)
- **Signed by Client** → **Fully Executed** (CAB countersignature)
- **Sent to Client** → **Expired** (30-day timeout)
- **Any State** → **Cancelled** (by either party before execution)

### State Invariants
- Contract in "Draft" MUST have all mandatory sections
- "Sent to Client" contracts MUST have expiry timer
- "Fully Executed" contracts MUST have both signatures and timestamps

## Integration Points

### Upstream
- Application Review outcomes
- Fee calculation engine
- Template management system

### Downstream
- Stage 1 Audit planning
- Financial system (invoicing)
- Document management system
- Client portal

## Contract Lifecycle Events

### Tracked Events
- Contract created
- Internal review completed
- Sent to client
- Client viewed (if portal used)
- Client signed
- CAB countersigned
- Amendments made
- Contract expired/cancelled

### Notifications
- Client: Contract ready for review
- Client: Reminder at 7, 14, 21 days
- CAB: Client has signed
- Both: Fully executed confirmation

## Performance Constraints

- Contract generation: < 30 seconds
- Template selection: < 2 seconds
- PDF rendering: < 10 seconds
- Electronic signature: < 5 minutes

## Error Handling

### BR-CON-ERR-001: Template Missing
- **Condition**: Required template not found
- **Response**: Alert administrator, use master template
- **Prevention**: Template completeness check daily

### BR-CON-ERR-002: Generation Failure
- **Condition**: System cannot generate contract
- **Response**: Queue for retry, notify administrator
- **Fallback**: Manual generation option

### BR-CON-ERR-003: Signature Timeout
- **Condition**: Client doesn't sign within 30 days
- **Response**: Auto-expire contract, notify both parties
- **Recovery**: Requires new contract generation

## Security Considerations

- Contract access limited to parties + authorized CAB staff
- All contract PDFs encrypted at rest
- Watermarking for draft versions
- Audit trail for all access and changes
- Secure transmission (encrypted email/portal)

## MVP Constraints

- Single contract template set (no customization UI)
- English language only
- Single currency (USD)
- Basic electronic signature (no advanced integration)
- Standard terms only (no negotiation tracking)
- No automated price calculations

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*