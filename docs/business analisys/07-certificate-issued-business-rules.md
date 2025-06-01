# Business Rules - Certificate Issued Stage

## Overview
The Certificate Issued stage represents the final step in the initial certification process where formal certificates are generated, quality checked, issued to clients, and registered in public databases. This stage transforms the certification decision into tangible credentials that clients can use to demonstrate conformity.

## Domain Context
- **Stage Type**: Document Generation and Distribution
- **Actors**: Certificate Administrator, Quality Reviewer, Client, System, Public Registry
- **ISO 17021 Reference**: Clause 9.5.2 - Certification documents

## Business Rules

### BR-CI-001: Certificate Generation Trigger
**Rule**: Certificates SHALL only be generated after positive decision
- **Prerequisites**:
  - Certification decision = "Grant Certification"
  - All minor NCs closed (evidence reviewed)
  - Payment obligations met
  - No pending appeals or complaints
- **Automatic Trigger**: Within 1 business day of decision
- **Manual Override**: Only by Quality Manager
- **Rationale**: Ensures all conditions met before issuance

### BR-CI-002: Certificate Unique Identifier
**Rule**: Each certificate MUST have a unique identifier
- **Format**: CAB-STD-YYYY-NNNNN
  - CAB: CAB identifier (3 letters)
  - STD: Standard code (e.g., QMS, EMS, OHS)
  - YYYY: Year of issuance
  - NNNNN: Sequential number
- **Examples**: 
  - UCB-QMS-2025-00001 (ISO 9001)
  - UCB-EMS-2025-00001 (ISO 14001)
- **Uniqueness**: System enforced, no duplicates
- **Rationale**: Traceability and verification

### BR-CI-003: Mandatory Certificate Content
**Rule**: Certificates MUST contain all required information
- **Required Elements**:
  - Certificate number (unique identifier)
  - Client legal name and address
  - Scope of certification (precise wording)
  - Applicable standard(s) with version
  - Date of initial certification
  - Certificate issue date
  - Certificate expiry date
  - CAB name and logo
  - Accreditation body logo and number
  - Authorizing signatures (digital)
- **Validation**: System prevents incomplete certificates
- **Rationale**: ISO 17021 Clause 9.5.2 requirements

### BR-CI-004: Scope Statement Accuracy
**Rule**: Certificate scope MUST exactly match approved scope
- **Verification Requirements**:
  - Word-for-word match with decision record
  - No additions or modifications allowed
  - Exclusions clearly stated if applicable
  - Site addresses complete and accurate
- **Quality Check**: Mandatory before release
- **Changes**: Require new certification decision
- **Rationale**: Prevents scope misrepresentation

### BR-CI-005: Certificate Validity Dates
**Rule**: Certificate dates SHALL follow standard rules
- **Date Calculations**:
  - Initial certification date: Date of positive decision
  - Issue date: Date of certificate generation
  - Expiry date: 3 years from initial certification date
  - Reissue maintains original initial date
- **No Backdating**: Issue date always current
- **No Extensions**: Expiry date immutable
- **Rationale**: Consistent certification cycles

### BR-CI-006: Multi-Site Certificate Handling
**Rule**: Multi-site certificates SHALL include all locations
- **Main Certificate**: Lists all sites in scope
- **Site Appendix**: Detailed list with:
  - Site names and addresses
  - Activities at each site
  - Central office designation
- **Optional**: Individual site sub-certificates
- **Page Numbering**: "Page X of Y" format
- **Rationale**: Complete scope visibility

### BR-CI-007: Multi-Standard Certificates
**Rule**: Multiple standards MAY be on single certificate
- **Combination Rules**:
  - Only for integrated management systems
  - Common scope required
  - All standards must be certified
  - Shortest expiry date applies
- **Alternative**: Separate certificates per standard
- **Client Choice**: If eligible for combined
- **Rationale**: Flexibility while maintaining clarity

### BR-CI-008: Certificate Language
**Rule**: Certificates SHALL be issued in defined languages
- **Primary**: English (mandatory)
- **Secondary**: Local language if requested
- **Translation**: Professional translation required
- **Verification**: Both versions QC checked
- **Legal Version**: English takes precedence
- **MVP Note**: English only in Phase 1
- **Rationale**: International recognition

### BR-CI-009: Digital Certificate Format
**Rule**: Certificates SHALL be primarily digital
- **Format Requirements**:
  - PDF/A format for archival
  - Digitally signed with certificate
  - Tamper-evident security features
  - Print-ready high resolution
  - Embedded metadata
- **Security Features**:
  - Digital watermark
  - QR code for verification
  - Unique document hash
- **Rationale**: Security and authenticity

### BR-CI-010: Certificate Quality Control
**Rule**: Every certificate MUST undergo QC before release
- **QC Checklist**:
  - Spelling and grammar
  - Data accuracy (dates, numbers)
  - Scope statement precision
  - Logo placement and quality
  - Digital signature validity
  - Security features active
- **QC Performer**: Different from generator
- **Evidence**: QC checklist retained
- **Rationale**: Professional quality assurance

### BR-CI-011: Certificate Distribution
**Rule**: Certificates SHALL be distributed securely
- **Distribution Methods**:
  - Secure email (encrypted)
  - Client portal download
  - Certified mail (if hard copy requested)
- **Confirmation**: Delivery receipt required
- **Timeline**: Within 5 business days of decision
- **Access Control**: Authorized recipient only
- **Rationale**: Secure delivery confirmation

### BR-CI-012: Public Registry Update
**Rule**: Issued certificates MUST be publicly registered
- **Registry Information**:
  - Certificate number
  - Client name
  - Scope of certification
  - Standard(s) certified
  - Valid from/to dates
  - Current status
- **Update Timeline**: Within 24 hours of issuance
- **Public Access**: Searchable database
- **Rationale**: Transparency and verification

### BR-CI-013: Certificate Verification Service
**Rule**: CAB SHALL provide certificate verification
- **Verification Methods**:
  - Online lookup by certificate number
  - QR code scanning
  - Email/phone verification service
- **Response Elements**:
  - Validity status
  - Scope confirmation
  - Expiry date
  - Any suspensions/withdrawals
- **Availability**: 24/7 online service
- **Rationale**: Combat certificate fraud

### BR-CI-014: Hard Copy Certificates
**Rule**: Physical certificates MAY be provided
- **When Provided**:
  - Client specific request
  - Local regulatory requirement
  - Additional fee may apply
- **Security Features**:
  - Security paper
  - Holographic elements
  - Embossed seal
  - Sequential numbering
- **Control**: Inventory tracking required
- **Rationale**: Some markets require physical

### BR-CI-015: Certificate Modifications
**Rule**: Issued certificates SHALL NOT be modified
- **Prohibition**: No changes after issuance
- **Required Changes**: Issue new certificate
- **Version Control**: New version number
- **Previous Version**: Marked superseded
- **Audit Trail**: All versions retained
- **Rationale**: Document integrity

### BR-CI-016: Certificate Suspension Marking
**Rule**: Suspended certificates MUST be clearly marked
- **Suspension Actions**:
  - Status updated in all systems
  - Public registry shows "Suspended"
  - Client notified immediately
  - Cannot use certificate during suspension
- **Restoration**: New certificate issued
- **Timeline**: Immediate upon suspension decision
- **Rationale**: Prevent misuse

### BR-CI-017: Certificate Withdrawal Process
**Rule**: Withdrawn certificates MUST be invalidated
- **Withdrawal Actions**:
  - Status = "Withdrawn" permanently
  - Public registry updated
  - Client must return/destroy
  - Legal notice if misuse continues
- **Irrevocable**: Cannot be reinstated
- **Documentation**: Withdrawal reason recorded
- **Rationale**: Clear termination

### BR-CI-018: Certificate Archive Requirements
**Rule**: All certificates SHALL be archived
- **Archive Requirements**:
  - Digital copy: Permanent retention
  - Metadata preserved
  - Searchable index
  - Backup copies maintained
  - Audit trail included
- **Access**: Restricted to authorized personnel
- **Retrieval**: Within 24 hours if needed
- **Rationale**: Long-term records

### BR-CI-019: Accreditation Mark Usage
**Rule**: Accreditation marks SHALL be used correctly
- **Usage Rules**:
  - Only current accreditation marks
  - Correct size and placement
  - Include accreditation number
  - Follow AB guidelines
- **Verification**: Part of QC process
- **Updates**: When accreditation renewed
- **Rationale**: Accreditation compliance

### BR-CI-020: Certificate Reissuance Triggers
**Rule**: Certificates MAY be reissued for valid reasons
- **Valid Triggers**:
  - Legal name change
  - Address change
  - Administrative error correction
  - Damage/loss (client request)
- **No Changes Allowed**:
  - Scope modifications
  - Validity dates
  - Standards covered
- **Process**: Requires authorization
- **Rationale**: Maintain accuracy

## State Transitions

### Valid State Transitions
- **Generation Pending** → **In Generation** (process started)
- **In Generation** → **QC Review** (certificate created)
- **QC Review** → **Approved** (QC passed)
- **QC Review** → **Rejected** (QC failed, regenerate)
- **Approved** → **Issued** (distributed to client)
- **Issued** → **Suspended** (if violations)
- **Issued** → **Withdrawn** (if terminated)
- **Suspended** → **Reissued** (if restored)

### State Invariants
- "Issued" certificates MUST be in public registry
- "Suspended" certificates MUST show suspension date
- "Withdrawn" certificates MUST show withdrawal reason

## Integration Points

### Upstream
- Certification decision system
- Payment verification
- Client database

### Downstream
- Public registry database
- Client portal
- Surveillance scheduling
- Marketing (success stories)
- Finance (completion)

## Performance Indicators

### Tracked Metrics
- Certificate issuance time (decision to delivery)
- QC pass rate (first time)
- Registry update timeliness
- Verification service usage
- Reissuance frequency

### Quality Indicators
- Certificate errors found post-issuance
- Client complaints about certificates
- Fraudulent certificate attempts
- Accreditation body findings

## Audit Trail Requirements

### Tracked Events
- Generation initiated
- QC performed
- Approval/rejection
- Distribution method
- Delivery confirmation
- Registry updates
- Verification queries
- Status changes

### Data Retention
- Certificate data: Permanent
- Generation logs: 5 years
- Distribution records: 3 years
- Verification logs: 1 year

## Error Handling

### BR-CI-ERR-001: Generation Failure
- **Condition**: System cannot generate certificate
- **Response**: Alert administrator, manual backup
- **Resolution**: Fix and regenerate
- **Client Impact**: Delay notification

### BR-CI-ERR-002: QC Rejection
- **Condition**: Certificate fails quality check
- **Response**: Return to generation with issues
- **Tracking**: QC failure reasons logged
- **Prevention**: Template updates

### BR-CI-ERR-003: Distribution Failure
- **Condition**: Cannot deliver to client
- **Response**: Multiple delivery attempts
- **Escalation**: Account manager contact
- **Alternative**: Portal availability

### BR-CI-ERR-004: Registry Sync Failure
- **Condition**: Public registry update fails
- **Response**: Queue for retry
- **Manual Override**: If persistent failure
- **Monitoring**: Daily sync reports

## Security Considerations

- Certificate templates access controlled
- Digital signatures HSM protected
- Generation audit trail immutable
- Secure storage encryption
- Distribution channel encryption
- Anti-counterfeit measures
- Regular security testing

## MVP Constraints

- English language only
- Single certificate design
- Basic QR code (no dynamic content)
- Manual QC process
- Email distribution primary
- Simple public registry
- No blockchain verification
- Standard PDF format only

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*