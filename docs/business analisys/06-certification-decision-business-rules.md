# Business Rules - Certification Decision Stage

## Overview
The Certification Decision stage is the formal process where an independent decision-maker reviews all audit evidence and makes the final determination on whether to grant, refuse, maintain, renew, suspend, restore, or withdraw certification. This ensures impartial decision-making separate from the audit process.

## Domain Context
- **Stage Type**: Independent Review and Decision
- **Actors**: Certification Decision Maker, Quality Manager, System
- **ISO 17021 Reference**: Clause 9.5 - Certification decision

## Business Rules

### BR-CD-001: Decision Maker Independence
**Rule**: Certification decision maker MUST be independent
- **Independence Requirements**:
  - Not involved in the audit (Stage 1 or Stage 2)
  - Not involved in application review
  - No conflict of interest with client
  - Competent in standard and decision-making
- **Verification**: System enforces role separation
- **Documentation**: Independence declaration on file
- **Rationale**: ISO 17021 Clause 9.5.1 impartiality requirement

### BR-CD-002: Decision Maker Competence
**Rule**: Decision maker MUST meet competence criteria
- **Competence Requirements**:
  - Understanding of applicable standard(s)
  - Knowledge of certification process
  - Trained in decision-making criteria
  - Experience with similar scopes (preferred)
  - Access to technical expertise if needed
- **Verification**: Competence matrix check
- **Assignment**: Based on availability and competence
- **Rationale**: Quality and consistency of decisions

### BR-CD-003: Information Requirements for Decision
**Rule**: Decision SHALL be based on complete information
- **Mandatory Information**:
  - Application and review records
  - Stage 1 audit report
  - Stage 2 audit report
  - Nonconformity details and classifications
  - Corrective action evidence (if submitted)
  - Audit team recommendation
  - Client response to findings
  - Any appeals or complaints
- **Validation**: System prevents decision without complete package
- **Rationale**: ISO 17021 Clause 9.5.1 sufficient information

### BR-CD-004: Decision Timeline
**Rule**: Certification decision MUST be timely
- **Timeline Requirements**:
  - Within 30 days of receiving complete information
  - Expedited for transfers (15 days)
  - Clock stops if additional info needed
  - Client notified if delay expected
- **Escalation**: Automatic alerts at 20, 25 days
- **Maximum**: 60 days absolute (unless justified)
- **Rationale**: Client service and business needs

### BR-CD-005: Decision Options
**Rule**: Decision maker SHALL select from defined options
- **For Initial Certification**:
  - **Grant Certification**: All requirements met
  - **Refuse Certification**: Major NC(s) not resolved
  - **Request Additional Information**: Clarification needed
  - **Request Follow-up Audit**: Major NCs require verification
- **Documentation**: Clear rationale for decision
- **Notification**: Formal communication to client
- **Rationale**: Clear and consistent outcomes

### BR-CD-006: Conditions for Granting Certification
**Rule**: Certification SHALL only be granted when conditions met
- **Required Conditions**:
  - No unresolved major nonconformities
  - Minor nonconformities have correction evidence
  - Audit covered entire scope
  - Audit team recommendation supports certification
  - No outstanding complaints
  - Contract obligations met (including payment)
- **Verification**: Checklist completion mandatory
- **Rationale**: Ensures system conformity

### BR-CD-007: Nonconformity Closure Verification
**Rule**: Decision maker MUST verify NC closure adequacy
- **Major NC Requirements**:
  - Root cause analysis reviewed
  - Correction implemented
  - Corrective action prevents recurrence
  - Evidence demonstrates effectiveness
  - May require on-site verification
- **Minor NC Requirements**:
  - Correction evidence adequate
  - Action plan acceptable
  - Timeline reasonable
- **Rationale**: Ensures effective resolution

### BR-CD-008: Follow-up Audit Triggers
**Rule**: Follow-up audit SHALL be required for specific conditions
- **Mandatory Triggers**:
  - Major nonconformity requiring on-site verification
  - Multiple majors indicating systemic issues
  - Significant scope areas not accessible
  - Evidence tampering or obstruction
- **Timing**: Within 90 days typically
- **Scope**: Limited to areas of concern
- **Rationale**: Verification of corrective actions

### BR-CD-009: Certification Refusal Process
**Rule**: Refusal decisions MUST follow defined process
- **Refusal Requirements**:
  - Clear statement of reasons
  - Reference to specific requirements not met
  - Options for client (correct and reapply)
  - Appeal process information
  - Timeline for reapplication (if applicable)
- **Communication**: Written notification required
- **Records**: Maintained for 5 years minimum
- **Rationale**: Transparency and improvement opportunity

### BR-CD-010: Multi-Site Certification Decisions
**Rule**: Multi-site decisions SHALL consider all sites
- **Decision Criteria**:
  - Central office must conform
  - Sample sites must conform
  - No site with major NC
  - System demonstrates control
- **Single Certificate**: Covers all sites in scope
- **Site Addition**: Requires decision update
- **Rationale**: System integrity across locations

### BR-CD-011: Conditional Certification
**Rule**: Conditional certification is NOT permitted
- **Principle**: Certificate issued only when fully conforming
- **Alternative**: Short-term surveillance may be added
- **Communication**: Clear to client - certified or not
- **Exception**: None allowed
- **Rationale**: ISO 17021 prohibition on conditional certificates

### BR-CD-012: Decision Documentation
**Rule**: All decisions MUST be comprehensively documented
- **Documentation Requirements**:
  - Decision form completed
  - Rationale statement
  - Evidence reviewed listed
  - Any consultations noted
  - Decision maker signature
  - Date and time of decision
- **Storage**: Permanent record in client file
- **Access**: Restricted to authorized personnel
- **Rationale**: Accountability and traceability

### BR-CD-013: Certificate Validity Period
**Rule**: Certificates SHALL have standard validity
- **Initial Certification**:
  - 3-year validity from decision date
  - Subject to surveillance audits
  - Contingent on continued conformity
- **Consistency**: Same validity for all certificates
- **No Extensions**: Expiry date cannot be extended
- **Early Renewal**: Allowed with new audit cycle
- **Rationale**: ISO 17021 certification cycle requirements

### BR-CD-014: Decision Review Rights
**Rule**: Clients SHALL have review rights for adverse decisions
- **Review Options**:
  - Request reconsideration with new evidence
  - Appeal to different decision maker
  - Escalate to impartial committee
- **Timeline**: 30 days to request review
- **Process**: Defined appeals procedure
- **No Retaliation**: Decision stands during appeal
- **Rationale**: Fair process and client rights

### BR-CD-015: Surveillance Program Definition
**Rule**: Certification decision MUST define surveillance program
- **Program Elements**:
  - First surveillance: Within 12 months
  - Second surveillance: Within 24 months
  - Risk-based adjustments allowed
  - Special audits if needed
- **Documentation**: Program included in decision record
- **Communication**: Client informed of obligations
- **Rationale**: Ongoing conformity verification

### BR-CD-016: Decision Communication
**Rule**: Decision SHALL be communicated formally
- **Communication Requirements**:
  - Written notification within 5 days
  - Clear statement of decision
  - Next steps outlined
  - Certificate issuance timeline (if approved)
  - Surveillance program (if approved)
  - Appeal rights (if refused)
- **Methods**: Email and client portal
- **Confirmation**: Delivery receipt required
- **Rationale**: Clear expectations and records

### BR-CD-017: Positive Decision Actions
**Rule**: Approved certifications SHALL trigger defined actions
- **Automatic Actions**:
  - Certificate generation request
  - Client portal status update
  - Surveillance scheduling initiated
  - Public registry update (after certificate issued)
  - Welcome package sent
- **Timeline**: Within 2 business days
- **Verification**: Checklist of completed actions
- **Rationale**: Consistent client experience

### BR-CD-018: Decision Integrity Controls
**Rule**: System SHALL prevent decision tampering
- **Control Measures**:
  - Decision locked after entry
  - Changes require new decision
  - Audit trail of all actions
  - Segregation of duties enforced
  - Time stamps tamper-proof
- **Monitoring**: Regular review of decision patterns
- **Alerts**: Unusual patterns flagged
- **Rationale**: Maintain certification integrity

## State Transitions

### Valid State Transitions
- **Awaiting Decision** → **Under Review** (assigned to decision maker)
- **Under Review** → **Additional Info Required** (clarification needed)
- **Under Review** → **Certification Granted** (requirements met)
- **Under Review** → **Certification Refused** (requirements not met)
- **Under Review** → **Follow-up Required** (verification needed)
- **Additional Info Required** → **Under Review** (info received)
- **Follow-up Required** → **Under Review** (after follow-up audit)

### State Invariants
- "Under Review" MUST have assigned decision maker
- "Certification Granted" MUST have validity dates
- "Certification Refused" MUST have documented reasons
- All states MUST have timestamp and actor recorded

## Integration Points

### Upstream
- Audit management system
- Nonconformity tracking
- Document management
- Payment verification

### Downstream
- Certificate generation
- Surveillance planning
- Public registry
- Client portal
- Finance (invoicing)

## Decision Matrix

| Scenario | Major NCs | Minor NCs | Decision | Action |
|----------|-----------|-----------|----------|---------|
| Clean audit | 0 | 0 | Grant | Issue certificate |
| Minor issues | 0 | 1-5 | Grant* | Certificate after evidence |
| Single major | 1 | Any | Follow-up | Verify correction |
| Multiple majors | >1 | Any | Refuse | Reaudit required |
| Obstruction | N/A | N/A | Refuse | Investigation |

*Subject to adequate corrective action evidence

## Performance Metrics

### Tracked KPIs
- Decision timeline compliance
- First-time approval rate
- Appeals/reversals rate
- Decision consistency score
- Customer satisfaction

### Quality Indicators
- Accreditation body findings on decisions
- Decision maker calibration results
- Appeals upheld vs. overturned

## Audit Trail Requirements

### Tracked Events
- Assignment to decision maker
- Information review started/completed
- Consultations (if any)
- Decision recorded
- Notifications sent
- Appeals received

### Retention
- Decision records: Permanent
- Supporting documents: 3 certification cycles
- Communication logs: 5 years

## Error Handling

### BR-CD-ERR-001: Incomplete Information
- **Condition**: Missing required documents
- **Response**: Request from source
- **Timeline**: 10 days to provide
- **Escalation**: To Quality Manager

### BR-CD-ERR-002: Conflict Discovered
- **Condition**: Decision maker conflict identified
- **Response**: Immediate reassignment
- **Documentation**: Reason for reassignment
- **Prevention**: Enhanced screening

### BR-CD-ERR-003: System Decision Mismatch
- **Condition**: Manual override of system recommendation
- **Response**: Additional justification required
- **Review**: Quality Manager approval
- **Documentation**: Detailed rationale

## Security Considerations

- Role-based access control
- Decision records encrypted
- Digital signatures required
- IP logging for all actions
- Segregation of duties enforced
- Regular access reviews

## MVP Constraints

- Single decision maker (no committee)
- Standard templates only
- English language only
- Manual competence verification
- Basic workflow (no complex routing)
- No AI-assisted decision support

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*