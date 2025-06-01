# Business Rules - Application Review Stage

## Overview
The Application Review stage evaluates client applications for completeness, feasibility, and CAB capability to deliver the requested certification services. This stage determines whether to proceed with contract generation or decline the application.

## Domain Context
- **Stage Type**: Decision Gateway
- **Actors**: Application Reviewer (Quality Manager/Senior Staff), Technical Expert (if needed), System
- **ISO 17021 Reference**: Clause 9.1.2 - Application review

## Business Rules

### BR-REV-001: Application Assignment
**Rule**: Applications MUST be assigned to qualified reviewers
- **Qualification Criteria**:
  - Minimum 3 years CAB experience
  - Knowledge of requested standard(s)
  - No conflict of interest with applicant
- **Assignment Method**: Auto-assign based on workload, manual override allowed
- **Timeframe**: Within 2 business days of receipt
- **Rationale**: Ensures competent and timely review

### BR-REV-002: Review Checklist Completion
**Rule**: Reviewers MUST complete standardized review checklist
- **Mandatory Sections**:
  - Scope clarity and feasibility
  - CAB competence availability
  - Geographic coverage capability
  - Resource availability
  - Certification timeline feasibility
  - Risk assessment
- **Completion**: All sections required before decision
- **Rationale**: ISO 17021 Clause 9.1.2 systematic review requirement

### BR-REV-003: Scope Feasibility Assessment
**Rule**: Requested scope MUST be evaluated against CAB capabilities
- **Assessment Criteria**:
  - Technical area coverage (NACE codes)
  - Required technical expertise availability
  - Language requirements
  - Geographic reach
  - Sector-specific regulations
- **Decision**: Clear "Can Deliver" / "Cannot Deliver" per criterion
- **Rationale**: Prevents accepting work beyond CAB competence

### BR-REV-004: Competence Verification
**Rule**: CAB MUST verify availability of competent audit team
- **Verification Requirements**:
  - At least one qualified Lead Auditor for standard
  - Technical expert for specific scope (if needed)
  - No conflicts of interest
  - Availability within requested timeframe
- **Documentation**: List potential team members in review record
- **Rationale**: ISO 17021 Clause 9.4 competence requirements

### BR-REV-005: Multi-Site Eligibility
**Rule**: Multi-site applications MUST meet eligibility criteria
- **Eligibility Requirements**:
  - Similar processes across sites
  - Central function control demonstrated
  - Internal audit program covering all sites
  - Management review of entire system
- **Sampling**: Calculate required sample size per IAF MD 1
- **Decision**: Eligible for sampling OR requires full site audits
- **Rationale**: ISO 17021 Annex A multi-site requirements

### BR-REV-006: Transfer Certification Validation
**Rule**: Transfer applications MUST verify current certification validity
- **Validation Steps**:
  - Verify certificate authenticity (may contact issuing CAB)
  - Confirm certificate not suspended/withdrawn
  - Review outstanding nonconformities
  - Assess certification cycle stage
- **Decision Criteria**: Accept transfer OR require new initial certification
- **Rationale**: IAF MD 2 transfer requirements

### BR-REV-007: Audit Duration Calculation
**Rule**: System SHALL calculate minimum audit duration
- **Calculation Basis**:
  - Employee numbers (including contractors)
  - Complexity category (High/Medium/Low)
  - Number of sites
  - Number of standards (if integrated)
  - Shift patterns
- **Reference**: ISO 17021 Annex B tables
- **Output**: Minimum person-days for Stage 1 + Stage 2
- **Rationale**: Ensures adequate audit time per standard

### BR-REV-008: Risk Level Assignment
**Rule**: Each application MUST be assigned a risk level
- **Risk Categories**:
  - **High**: Regulated sectors, high environmental/safety impact
  - **Medium**: Standard commercial operations
  - **Low**: Office-based, low-impact activities
- **Risk Factors**:
  - Sector criticality
  - Regulatory requirements
  - Previous certification issues
  - Scope complexity
- **Impact**: Determines review depth and audit approach
- **Rationale**: Risk-based thinking per ISO 17021

### BR-REV-009: Timeline Feasibility Check
**Rule**: Requested timeline MUST be evaluated against capacity
- **Evaluation Criteria**:
  - Auditor availability
  - Current workload
  - Seasonal constraints
  - Client readiness indicators
- **Response Options**:
  - Accept requested timeline
  - Propose alternative timeline
  - Decline if impossible
- **Rationale**: Realistic planning prevents future conflicts

### BR-REV-010: Information Sufficiency Assessment
**Rule**: Reviewer MUST determine if additional information needed
- **Common Requests**:
  - Organization chart
  - Process descriptions
  - Site layouts
  - Previous audit reports
  - Management system documentation list
- **Request Method**: Formal information request with deadline
- **Timeout**: 30 days for client response
- **Rationale**: Complete information enables accurate planning

### BR-REV-011: Review Decision Documentation
**Rule**: Review decision MUST be formally documented
- **Required Elements**:
  - Decision (Accept/Decline/Need Information)
  - Rationale for decision
  - Any conditions or limitations
  - Identified risks or concerns
  - Reviewer name and date
- **Approval**: Decisions recorded with digital signature equivalent
- **Rationale**: Demonstrates due diligence and decision basis

### BR-REV-012: Decline Justification
**Rule**: Application declines MUST include specific justification
- **Valid Decline Reasons**:
  - Outside CAB scope of accreditation
  - No available competent resources
  - Unacceptable conflict of interest
  - Client location not serviceable
  - Unacceptable certification risk
- **Communication**: Written explanation to client
- **Appeal**: Client may appeal with additional information
- **Rationale**: Transparency and potential for resolution

### BR-REV-013: Conditional Acceptance
**Rule**: Applications MAY be conditionally accepted
- **Allowed Conditions**:
  - Scope clarification required
  - Specific documents needed before Stage 1
  - Timeline adjustment needed
  - Additional sites require separate assessment
- **Documentation**: Conditions clearly stated in contract
- **Resolution**: Conditions must be resolved before Stage 1
- **Rationale**: Flexibility while maintaining requirements

### BR-REV-014: Review Timeline SLA
**Rule**: Reviews MUST be completed within defined timeframes
- **Standard Review**: 5 business days
- **Complex Review** (multi-site/multi-standard): 10 business days
- **Clock Stops**: When additional information requested
- **Escalation**: Automatic notification if SLA exceeded
- **Rationale**: Maintains service quality and client satisfaction

### BR-REV-015: Impartiality Review
**Rule**: Each application MUST undergo impartiality assessment
- **Review Areas**:
  - Consultancy provided in last 2 years
  - Financial interests
  - Personal relationships
  - Competitive relationships
- **Documentation**: Impartiality declaration from assigned team
- **Decision**: Proceed OR reassign OR decline
- **Rationale**: ISO 17021 Clause 5 impartiality requirements

## State Transitions

### Valid State Transitions
- **Under Review** → **Approved** (proceed to contract)
- **Under Review** → **Information Requested** (need client input)
- **Under Review** → **Declined** (cannot provide service)
- **Information Requested** → **Under Review** (info received)
- **Information Requested** → **Withdrawn** (timeout/client decision)

### State Invariants
- Application in "Under Review" MUST have:
  - Assigned reviewer
  - Review start timestamp
  - Target completion date
- "Approved" applications MUST have:
  - Completed review checklist
  - Audit duration calculation
  - Risk assessment
  - Potential audit team identified

## Integration Points

### Upstream
- Application Received process
- Auditor competence database
- Conflict of interest register

### Downstream
- Contract Generation process
- Audit planning system
- Client communication system

## Decision Matrix

| Criterion | Pass | Fail Action |
|-----------|------|-------------|
| Scope within accreditation | ✓ Continue | → Decline |
| Competent auditors available | ✓ Continue | → Decline/Delay |
| No conflicts of interest | ✓ Continue | → Reassign/Decline |
| Geographic coverage | ✓ Continue | → Decline/Partner |
| Timeline feasible | ✓ Continue | → Negotiate/Decline |
| Acceptable risk level | ✓ Continue | → Decline/Conditions |

## Audit Trail Requirements

### Tracked Events
- Review assignment
- Checklist completion stages
- Information requests sent
- Client responses received
- Decision made
- Decision approval

### Retention
- Review records: Minimum 3 certification cycles
- Decision rationale: Permanent

## Performance Constraints

- Review assignment: < 1 hour from receipt
- Audit duration calculation: < 10 seconds
- Risk assessment: < 2 minutes
- Decision recording: Real-time

## Error Handling

### BR-REV-ERR-001: Competence Gap
- **Condition**: No qualified auditors available
- **Response**: Flag for management attention
- **Options**: Training, subcontracting, or decline

### BR-REV-ERR-002: Information Timeout
- **Condition**: Client doesn't respond within 30 days
- **Response**: Auto-withdraw application
- **Notification**: Warning at 20 days, final at 25 days

### BR-REV-ERR-003: Calculation Error
- **Condition**: Audit duration calculation fails
- **Response**: Flag for manual calculation
- **Fallback**: Use standard tables directly

## Security Considerations

- Review decisions require authentication
- Sensitive client data masked in logs
- Impartiality declarations encrypted
- Access limited to assigned reviewer + management

## MVP Constraints

- Single reviewer per application (no team reviews)
- English language documentation only
- Standard risk categories only (no custom)
- Manual override for all automated decisions
- No integration with external databases

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*