# Domain Ubiquitous Language

## Overview

This document defines the ubiquitous language used throughout the U-Certify platform. All terms should be used consistently across documentation, code, and communication within the development team and stakeholders.

---

## Core Domain Entities

### Certification Bodies & Assessment

- **CAB (Conformity Assessment Body)**: An organization that provides certification services and maintains accreditation to conduct management system assessments
- **Accreditation Body**: The authority that grants and maintains accreditation to CABs (e.g., ANAB, UKAS)
- **Assessment**: The systematic evaluation of a client's management system against standard requirements
- **Audit**: Systematic examination of management system implementation and effectiveness
- **Auditor**: Qualified individual who conducts assessments of client management systems
- **Lead Auditor**: Senior auditor responsible for managing audit team and making certification recommendations
- **Technical Expert**: Subject matter expert who supports audit team with specialized knowledge but cannot audit independently
- **Decision Maker**: Independent person responsible for certification decisions, separate from audit team

### Certification Process Stages

- **Application**: Initial client request for certification services with scope and requirements
- **Application Review**: CAB evaluation of application for feasibility and resource requirements
- **Contract**: Formal agreement between CAB and client defining certification scope and terms
- **Stage 1 Audit**: Preliminary assessment focused on readiness evaluation and documentation review
- **Stage 2 Audit**: Main conformity assessment evaluating full implementation and effectiveness
- **Certification Decision**: Formal determination to grant, refuse, or require additional actions
- **Certificate Issuance**: Generation and delivery of formal certification document
- **Surveillance Audit**: Periodic audit to verify continued conformity (typically annual)
- **Recertification**: Full re-assessment at end of 3-year certification cycle

### Client & Scope Management

- **Client**: Organization seeking certification of their management system
- **Scope**: Defined boundaries of what is included in the certification (activities, processes, locations)
- **Standard**: Requirements specification (e.g., ISO 9001, ISO 14001, ISO 45001)
- **Multi-Site**: Certification covering multiple locations under single management system
- **Central Office**: Primary location that controls multi-site management system
- **Site**: Individual location included in certification scope
- **Sampling**: Selection of subset of sites for audit in multi-site certifications

---

## Assessment & Findings

### Nonconformities & Findings

- **Nonconformity (NC)**: Failure to meet specified standard requirement
- **Major Nonconformity**: Significant failure that affects system capability or integrity
- **Minor Nonconformity**: Isolated or limited failure that doesn't affect overall system
- **Observation**: Noted practice that could lead to nonconformity if not addressed
- **Opportunity for Improvement (OFI)**: Suggestion for enhancement beyond minimum compliance
- **Finding**: Any conclusion reached during audit (NC, observation, or positive practice)
- **Objective Evidence**: Verifiable information supporting audit findings

### Corrective Actions & Follow-up

- **Correction**: Immediate action to fix identified problem
- **Corrective Action**: Action to eliminate root cause and prevent recurrence
- **Root Cause Analysis**: Investigation to identify underlying cause of nonconformity
- **Follow-up Audit**: Additional audit to verify correction of major nonconformities
- **Closure**: Verification that corrective actions are adequate and effective

---

## Standards & Compliance

### Management System Standards

- **ISO 9001**: Quality Management Systems standard
- **ISO 14001**: Environmental Management Systems standard
- **ISO 45001**: Occupational Health and Safety Management Systems standard
- **Integrated Management System**: Single system addressing multiple standards
- **Management System**: Set of policies, processes, and procedures used to achieve objectives

### Accreditation Standards

- **ISO 17021-1**: Requirements for management system certification bodies
- **IAF (International Accreditation Forum)**: Global association of accreditation bodies
- **IAF MD (Mandatory Document)**: Binding requirements for accredited CABs
- **Accreditation**: Formal recognition of CAB competence to perform specific activities
- **Scope of Accreditation**: Defined activities and technical areas CAB is authorized to perform

---

## Process & Workflow States

### Application States

- **Received**: Application submitted and acknowledged
- **Under Review**: Application being evaluated for feasibility
- **Information Requested**: Additional information needed from client
- **Approved**: Application accepted, ready for contract generation
- **Rejected**: Application declined due to inability to provide service
- **Withdrawn**: Client cancelled application

### Assessment States

- **Planned**: Audit scheduled with dates and team assigned
- **In Progress**: Audit actively being conducted
- **Completed**: Audit finished, findings documented
- **Report Issued**: Audit report delivered to client
- **Awaiting Decision**: Ready for certification decision maker review

### Certification States

- **Certified**: Valid certificate issued and active
- **Suspended**: Certificate temporarily invalid due to serious issues
- **Withdrawn**: Certificate permanently cancelled
- **Expired**: Certificate past validity date without renewal

---

## Quality & Risk Management

### Competence & Qualification

- **Competence**: Demonstrated ability to perform specific activities
- **Qualification**: Formal credentials or training completion
- **Competence Matrix**: Grid showing auditor capabilities against standards and scopes
- **Continuing Professional Development (CPD)**: Ongoing learning to maintain competence
- **Conflict of Interest**: Situation where impartiality could be compromised

### Risk & Business Rules

- **Risk Assessment**: Evaluation of potential threats to certification integrity
- **Business Rule**: Codified requirement that governs system behavior
- **Invariant**: Condition that must always be true for valid system state
- **SLA (Service Level Agreement)**: Committed performance standard
- **Escalation**: Process for handling overdue or problematic situations

---

## Data & Documentation

### Document Management

- **Document Control**: Systematic management of document versions and access
- **Record**: Document providing evidence of activities performed or results achieved
- **Version Control**: Management of document changes over time
- **Audit Trail**: Complete history of actions taken on data or documents
- **Retention Period**: Required time to maintain records

### System Integration

- **Integration Point**: Connection between system modules or external systems
- **Upstream**: System or process that provides input
- **Downstream**: System or process that receives output
- **API (Application Programming Interface)**: Defined methods for system communication
- **Workflow Engine**: Component that manages business process execution

---

## Performance & Metrics

### Key Performance Indicators

- **KPI (Key Performance Indicator)**: Measurable value indicating performance
- **Compliance Score**: Metric indicating adherence to requirements
- **Utilization Rate**: Percentage of available auditor time used productively
- **Cycle Time**: Total time from application to certificate issuance
- **First-Time Approval Rate**: Percentage of audits resulting in immediate certification

### Quality Indicators

- **Customer Satisfaction**: Client rating of service quality
- **Appeals Rate**: Percentage of decisions challenged by clients
- **Accreditation Body Findings**: Issues identified during accreditation audits
- **System Availability**: Percentage of time platform is operational

---

## Business Context

### Stakeholders

- **Management**: CAB leadership responsible for strategic decisions
- **Quality Manager**: Person responsible for maintaining accreditation compliance
- **Administrative Staff**: Personnel handling scheduling, documentation, and client communication
- **IT Department**: Technical team managing system infrastructure and support

### Commercial Terms

- **Revenue per CAB**: Average annual income from certification body client
- **Market Penetration**: Percentage of target market using the platform
- **Churn Rate**: Percentage of customers discontinuing service
- **Total Addressable Market (TAM)**: Complete market opportunity
- **Minimum Viable Product (MVP)**: Basic version with core features for initial release

---

## Technical Implementation

### System Architecture

- **Domain**: Core business area with specific rules and processes
- **Bounded Context**: Explicit boundary where domain model applies
- **Aggregate**: Cluster of related objects treated as single unit
- **Entity**: Object with distinct identity that persists over time
- **Value Object**: Immutable object defined by its attributes

### Data Management

- **State Transition**: Valid change from one status to another
- **Event Sourcing**: Storing sequence of events rather than current state
- **CQRS (Command Query Responsibility Segregation)**: Separate models for reading and writing
- **Eventual Consistency**: Data consistency achieved over time rather than immediately

---

## Abbreviations & Acronyms

- **BR**: Business Rule (e.g., BR-CD-001)
- **CAB**: Conformity Assessment Body
- **CPD**: Continuing Professional Development
- **CQRS**: Command Query Responsibility Segregation
- **FTE**: Full-Time Equivalent
- **IAF**: International Accreditation Forum
- **KPI**: Key Performance Indicator
- **MD**: Mandatory Document
- **MVP**: Minimum Viable Product
- **NC**: Nonconformity
- **OFI**: Opportunity for Improvement
- **QMS**: Quality Management System
- **ROI**: Return on Investment
- **SLA**: Service Level Agreement
- **TAM**: Total Addressable Market
- **UX**: User Experience

---

## Usage Guidelines

### Communication Standards

1. **Always use defined terms** rather than synonyms or variations
2. **Capitalize proper terms** when referring to specific domain concepts
3. **Use full term on first reference** then abbreviation if commonly used
4. **Maintain consistency** across all documentation and code

### Code Implementation

1. **Class names should reflect domain terms** (e.g., `CertificationDecision`, not `Decision`)
2. **Method names should use domain verbs** (e.g., `GrantCertification`, not `Approve`)
3. **Database tables should match entities** with consistent naming
4. **API endpoints should use domain language** for clarity

### Documentation Standards

1. **Business rules should reference this language** for consistency
2. **User stories should use domain terms** familiar to stakeholders
3. **Technical specifications should bridge** domain and implementation concepts
4. **Training materials should reinforce** ubiquitous language usage

---

*Document Version: 1.0*
*Last Updated: 2025-05-31*
*Review Frequency: Quarterly*

**Note**: This ubiquitous language should be treated as a living document, updated as domain understanding evolves and new concepts are discovered during development.
