# Business Rules - Stage 1 Audit

## Overview
The Stage 1 Audit is a preliminary assessment to determine client readiness for Stage 2 certification audit. It focuses on understanding the management system, evaluating documentation, confirming scope, and identifying potential nonconformities that could be classified as major during Stage 2.

## Domain Context
- **Stage Type**: Readiness Assessment
- **Actors**: Lead Auditor, Audit Team Members, Client Management Representative, System
- **ISO 17021 Reference**: Clause 9.3.1.2 - Stage 1 audit

## Business Rules

### BR-S1-001: Stage 1 Audit Prerequisites
**Rule**: Stage 1 audit SHALL NOT commence without prerequisites met
- **Required Prerequisites**:
  - Fully executed contract
  - Audit team assigned and accepted by client
  - Audit plan issued (minimum 7 days prior)
  - Client management system documentation available
  - Payment received (or payment terms confirmed)
- **Validation**: System blocks audit start without prerequisites
- **Rationale**: Ensures proper preparation and authorization

### BR-S1-002: Audit Team Assignment
**Rule**: Audit team MUST meet competence requirements
- **Team Composition**:
  - Lead Auditor (mandatory)
  - Technical Expert (if scope requires)
  - Auditor(s) (based on audit duration)
  - Interpreter (if needed - not counted in duration)
- **Competence Verification**:
  - Lead Auditor qualified for standard and scope
  - Technical Expert for specific technical areas
  - No conflicts of interest declared
- **Client Acceptance**: Right to object with valid reasons
- **Rationale**: ISO 17021 Clause 9.2.2 team competence

### BR-S1-003: Audit Plan Requirements
**Rule**: Stage 1 audit plan MUST cover mandatory elements
- **Mandatory Elements**:
  - Audit objectives (readiness determination)
  - Audit criteria (standard requirements)
  - Audit scope (locations, processes)
  - Audit schedule (dates, times, participants)
  - Team member roles
  - Documentation review plan
  - Logistics (meeting rooms, PPE, etc.)
- **Distribution**: Client, audit team, CAB office
- **Language**: Client's business language (English for MVP)
- **Rationale**: ISO 17021 Clause 9.2.3.1 planning requirements

### BR-S1-004: Stage 1 Audit Objectives
**Rule**: Stage 1 audit MUST achieve defined objectives
- **Primary Objectives**:
  - Review management system documentation
  - Evaluate location conditions and site-specific issues
  - Review client status and understanding of standard
  - Confirm resource allocation for Stage 2
  - Review scope and process interfaces
  - Assess readiness for Stage 2
- **Documentation**: Each objective assessed and recorded
- **Rationale**: ISO 17021 Clause 9.3.1.2.1 requirements

### BR-S1-005: Documentation Review Scope
**Rule**: Stage 1 MUST review key system documentation
- **Mandatory Documents**:
  - Management system manual (or equivalent)
  - Policy statements
  - Process descriptions/maps
  - Objectives and targets
  - Management review records
  - Internal audit program and results
  - Document control procedures
- **Review Depth**: Adequacy, not detailed implementation
- **Output**: Documentation review report
- **Rationale**: Determines system establishment

### BR-S1-006: On-Site Activities Requirement
**Rule**: Stage 1 SHOULD be conducted at client premises
- **On-Site Purposes**:
  - Understand physical layout
  - Assess site-specific conditions
  - Interview key personnel
  - Evaluate resource adequacy
  - Confirm audit logistics
- **Remote Option**: Only if justified and documented
- **Multi-Site**: Central office mandatory, sample of sites
- **Rationale**: ISO 17021 Clause 9.3.1.2.2 preference

### BR-S1-007: Stage 1 Duration Limits
**Rule**: Stage 1 duration SHALL be proportionate
- **Duration Guidelines**:
  - Typically 20-30% of total Stage 1+2 time
  - Minimum: 0.5 person-day
  - Maximum: Not exceed Stage 2 duration
- **Documentation**: Actual time recorded
- **Billing**: As per contract terms
- **Rationale**: Balanced effort distribution

### BR-S1-008: Readiness Determination
**Rule**: Stage 1 MUST conclude with readiness decision
- **Decision Options**:
  - **Ready**: Proceed to Stage 2 as planned
  - **Conditionally Ready**: Minor issues to resolve
  - **Not Ready**: Significant gaps requiring delay
- **Criteria**: No potential major nonconformities identified
- **Documentation**: Clear rationale for decision
- **Rationale**: Prevents unsuccessful Stage 2 audits

### BR-S1-009: Finding Classification
**Rule**: Stage 1 findings SHALL be classified appropriately
- **Classifications**:
  - **Major Concern**: Would be major NC in Stage 2
  - **Minor Concern**: Would be minor NC in Stage 2
  - **Observation**: Improvement opportunity
  - **Positive Practice**: Noteworthy achievement
- **Key Point**: No formal nonconformities issued in Stage 1
- **Communication**: Written report to client
- **Rationale**: Stage 1 is readiness, not conformity assessment

### BR-S1-010: Stage 2 Planning Confirmation
**Rule**: Stage 1 MUST confirm or revise Stage 2 plan
- **Planning Elements**:
  - Audit duration adequacy
  - Team composition appropriateness
  - Audit dates feasibility
  - Sample selection (for multi-site)
  - Special focus areas identified
- **Changes**: Documented and agreed with client
- **Notification**: Minimum 14 days for significant changes
- **Rationale**: Ensures Stage 2 effectiveness

### BR-S1-011: Stage 1 Report Requirements
**Rule**: Stage 1 report MUST be comprehensive
- **Report Sections**:
  - Executive summary with readiness conclusion
  - Objectives achievement assessment
  - Documentation review results
  - Areas of concern (potential nonconformities)
  - Positive observations
  - Stage 2 audit plan confirmation/changes
  - Any unresolved issues
- **Timeline**: Issued within 10 business days
- **Distribution**: Client and CAB records
- **Rationale**: Clear communication and records

### BR-S1-012: Client Response Time
**Rule**: Client SHALL have defined time to address concerns
- **Response Requirements**:
  - Major concerns: Must address before Stage 2
  - Minor concerns: Plan required, implementation by Stage 2
  - Observations: Optional response
- **Maximum Delay**: 6 months between Stage 1 and Stage 2
- **Re-audit**: Required if delay exceeds 6 months
- **Rationale**: Maintains momentum while allowing preparation

### BR-S1-013: Internal Audit Verification
**Rule**: Stage 1 MUST verify internal audit completion
- **Verification Requirements**:
  - Full cycle completed (all processes/areas)
  - Competent internal auditors used
  - Findings addressed appropriately
  - Results reported to management
- **Timing**: Within 12 months of Stage 1
- **Evidence**: Audit reports, corrective actions
- **Rationale**: ISO standard requirement for certification

### BR-S1-014: Management Review Verification
**Rule**: Stage 1 MUST verify management review conducted
- **Verification Requirements**:
  - Covers all required inputs
  - Top management participation
  - Decisions and actions recorded
  - Conducted after internal audits
- **Timing**: Within 12 months of Stage 1
- **Evidence**: Meeting minutes, action plans
- **Rationale**: Demonstrates management commitment

### BR-S1-015: Confidentiality During Stage 1
**Rule**: All Stage 1 information SHALL remain confidential
- **Confidentiality Scope**:
  - Client documentation reviewed
  - Processes observed
  - Information gathered
  - Findings identified
- **Exceptions**: Only as per contract terms
- **Team Briefing**: Reminder before audit
- **Rationale**: Maintains trust and legal compliance

## State Transitions

### Valid State Transitions
- **Planned** → **In Progress** (audit commenced)
- **In Progress** → **Completed** (audit finished)
- **Completed** → **Report Issued** (within 10 days)
- **Planned** → **Postponed** (client/CAB request)
- **Postponed** → **Planned** (rescheduled)
- **Any State** → **Cancelled** (contract terminated)

### State Invariants
- "In Progress" audits MUST have team on-site/connected
- "Completed" audits MUST have readiness decision
- "Report Issued" MUST have client acknowledgment tracking

## Integration Points

### Upstream
- Contract management (terms and scope)
- Audit team competence database
- Audit planning system

### Downstream
- Stage 2 audit planning
- Finding tracking system
- Client communication portal
- Report generation system

## Performance Indicators

### Tracked Metrics
- Stage 1 to Stage 2 conversion rate
- Average days between Stage 1 and Stage 2
- Percentage requiring Stage 2 delay
- Major concerns identified rate
- Client satisfaction scores

### Quality Metrics
- Report issuance within SLA: Target 95%
- Stage 2 success rate after Stage 1: Target 90%
- Client readiness accuracy: Target 85%

## Audit Trail Requirements

### Tracked Events
- Audit plan issued
- Audit started/ended
- Documents reviewed
- Findings recorded
- Report generated
- Report issued
- Client acknowledgment

### Evidence Collection
- Documentation review checklist
- Interview notes (summary level)
- Site tour observations
- Time records by activity

## Error Handling

### BR-S1-ERR-001: Documentation Unavailable
- **Condition**: Key documents not provided
- **Response**: Document in report, assess impact
- **Decision**: May determine "Not Ready"

### BR-S1-ERR-002: Client Unpreparedness
- **Condition**: Significant readiness gaps found
- **Response**: Stop audit if productive work impossible
- **Billing**: Per contract cancellation terms

### BR-S1-ERR-003: Team Member Unavailable
- **Condition**: Assigned auditor cannot attend
- **Response**: Replace with qualified alternate
- **Approval**: Client notification and acceptance

## Security Considerations

- Client documents accessed view-only
- No client data stored on personal devices
- Secure transmission of reports
- Finding details not shared beyond client/CAB
- VPN required for remote documentation review

## MVP Constraints

- English language audits only
- Single site Stage 1 in one visit
- Standard report templates only
- No real-time client portal updates
- Manual time tracking
- Basic finding categorization (no AI assist)

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*ISO 17021-1:2015 Alignment Verified*