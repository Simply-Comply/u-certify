---
applyTo: "**"
---

# UCertify - Project Context

## Project Overview
UCertify is a cloud-based compliance management system for Conformity Assessment Bodies (CABs) - organizations that certify other companies against standards like ISO 9001, ISO 14001, etc. Think of it as "Salesforce for certification bodies."

## Business Context
- **Problem**: 70% of CABs use paper/Excel, causing compliance issues and inefficiency
- **Solution**: Digital platform automating certification workflows while ensuring accreditation compliance
- **MVP Focus**: ISO/IEC 17021-1:2015 standard (management system certification)
- **Users**: Auditors, quality managers, CAB administrators

## Technical Stack
```
Backend:
- .NET 9 with ASP.NET Core Web API
- Clean Architecture + Domain-Driven Design (DDD)
- CQRS pattern with MediatR
- Entity Framework Core + PostgreSQL
- KeyCloak for identity management
- .NET Aspire for orchestration

Frontend:
- React 19 with TypeScript
- Vite build tool
- Bulletproof React architecture
- TanStack Query for data fetching
- Responsive + PWA capabilities
```

## Architecture Decisions
- **Modular monolith** architecture pattern
- **Multi-tenant SaaS** with row-level security
- **Plugin architecture** for extending to new standards
- **Event-driven** for audit trail and compliance tracking
- **Offline-first** for mobile auditors
- **API-first** design for future integrations

## Current Development Phase
Building MVP (Month 1-8) with focus on:
1. Core compliance engine
2. Assessment workflow (Stage 1, Stage 2, Surveillance)
3. Finding management with evidence
4. Report generation
5. Basic analytics dashboard

## Key Business Rules
- Auditors must be qualified for specific standards
- Assessment duration calculated based on client size/complexity
- Findings classified as Major/Minor/Observation
- 3-year certification cycle with annual surveillance
- Complete audit trail for accreditation bodies

## Project Structure
```
src/
├── UCertify.Api/              # REST API endpoints
├── UCertify.Application/      # Use cases (CQRS commands/queries)
├── UCertify.Domain/           # Business logic & entities
├── UCertify.Infrastructure/   # External services, DB
└── UCertify.Tests/            # Unit & integration tests
```

## Development Approach
- Lean team: 1 senior developer + 1 domain expert
- AI-augmented development (3-5x productivity)
- 8-month timeline to MVP
- Focus on extensibility for future standards

## Special Considerations
1. **Compliance First**: Every feature must maintain audit trail
2. **Data Isolation**: Strict tenant separation (competitors use same platform)
3. **Offline Capability**: Auditors work in facilities without internet
4. **Extensibility**: Must easily add new standards (ISO 17025, 17020, etc.)
5. **Trust**: Security and data integrity are paramount

## Example Use Case
```
Auditor conducts ISO 9001 assessment:
1. Plans audit in system (dates, scope, team)
2. Reviews client documents online
3. Conducts on-site audit (offline mobile)
4. Records findings with photo evidence
5. Generates report from templates
6. Client receives corrective action requests
7. Tracks corrections until closure
8. Issues certificate when compliant
```

## Common Acronyms
- CAB: Conformity Assessment Body
- NCR: Non-Conformity Report  
- CAPA: Corrective and Preventive Action
- QMS: Quality Management System