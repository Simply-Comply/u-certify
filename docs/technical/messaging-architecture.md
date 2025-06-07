# UCertify Messaging Architecture

## Overview

This document defines the messaging architecture for UCertify, leveraging MassTransit as the service bus abstraction layer with RabbitMQ as the message broker. The architecture supports both in-process communication within the modular monolith and distributed messaging for future microservices extraction.

## Technology Stack

### Core Messaging Components

- **MediatR**: In-process message dispatcher for domain events and CQRS within modules
- **MassTransit**: Service bus abstraction for inter-module and distributed messaging
- **RabbitMQ**: Enterprise message broker for reliable, scalable message delivery
- **Event Store**: Optional event sourcing for audit trail and event replay capabilities

### Architecture Layers

```mermaid
graph TB
    subgraph "Application Layer"
        APP[Application Services]
        CQRS[Commands/Queries]
    end
    
    subgraph "Domain Layer"
        AGG[Aggregates]
        DE[Domain Events]
        DS[Domain Services]
    end
    
    subgraph "Messaging Infrastructure"
        MED[MediatR<br/>In-Process Events]
        MT[MassTransit<br/>Service Bus]
    end
    
    subgraph "Message Transport"
        RMQ[RabbitMQ<br/>Message Broker]
        ES[Event Store<br/>Event Persistence]
    end
    
    APP --> CQRS
    CQRS --> MED
    AGG --> DE
    DE --> MED
    MED --> MT
    MT --> RMQ
    MT --> ES
```

## Message Types and Patterns

### Message Classification

#### 1. Domain Events
Internal state change notifications within the domain model.

**Characteristics**:
- Immutable
- Past tense naming
- Contains all relevant state
- Published after state change
- Tenant-scoped

**Examples**:
- `ApplicationApproved`
- `FindingRecorded`
- `CertificateIssued`

#### 2. Integration Events
Cross-module notifications requiring eventual consistency.

**Characteristics**:
- Module boundary crossing
- Asynchronous processing
- Retry policies
- Versioned contracts
- Tenant isolation enforced

**Examples**:
- `ClientRegistrationCompleted`
- `AssessmentReadyForScheduling`
- `ComplianceViolationDetected`

#### 3. Commands
Directed operations requesting specific actions.

**Characteristics**:
- Imperative mood
- Single handler
- Can fail/be rejected
- Synchronous or asynchronous
- Returns result/acknowledgment

**Examples**:
- `ScheduleAssessment`
- `AssignAuditorToTeam`
- `GenerateComplianceReport`

#### 4. Queries
Read operations requesting data without side effects.

**Characteristics**:
- Request-response pattern
- No state changes
- Can be cached
- Cross-module data aggregation

**Examples**:
- `GetAvailableAuditors`
- `GetClientCertificationHistory`
- `GetComplianceMetrics`

### Message Flow Patterns

```mermaid
graph LR
    subgraph "Publish-Subscribe Pattern"
        P1[Publisher] --> E1[Event]
        E1 --> S1[Subscriber 1]
        E1 --> S2[Subscriber 2]
        E1 --> S3[Subscriber 3]
    end
    
    subgraph "Request-Response Pattern"
        R1[Requestor] --> Q1[Query]
        Q1 --> H1[Handler]
        H1 --> R2[Response]
        R2 --> R1
    end
    
    subgraph "Command Pattern"
        C1[Commander] --> CMD[Command]
        CMD --> H2[Handler]
        H2 --> ACK[Acknowledgment]
        ACK --> C1
    end
```

## Tenant-Aware Messaging

### Tenant Context Propagation

All messages include tenant context to ensure proper isolation:

```mermaid
sequenceDiagram
    participant Sender
    participant MessageBus
    participant RabbitMQ
    participant Receiver
    
    Sender->>MessageBus: Send Message + TenantId
    MessageBus->>MessageBus: Add Tenant Headers
    MessageBus->>RabbitMQ: Route to Tenant Exchange
    RabbitMQ->>Receiver: Deliver to Tenant Queue
    Receiver->>Receiver: Validate Tenant Context
    Receiver->>Receiver: Process Message
```

### Tenant Routing Strategy

#### Small-Medium Tenants
- Shared exchanges with tenant filtering
- Message headers contain tenant identifier
- Consumer-side filtering

#### Large Enterprise Tenants
- Dedicated exchanges and queues
- Physical isolation at broker level
- Priority message processing

### Multi-Tenant Exchange Topology

```mermaid
graph TB
    subgraph "RabbitMQ Topology"
        subgraph "Shared Infrastructure"
            SE[Shared Exchange]
            SQ1[Shared Queue 1]
            SQ2[Shared Queue 2]
        end
        
        subgraph "Dedicated Tenant Resources"
            TE1[Tenant A Exchange]
            TQ1[Tenant A Queue]
            TE2[Tenant B Exchange]
            TQ2[Tenant B Queue]
        end
    end
    
    SE --> SQ1
    SE --> SQ2
    TE1 --> TQ1
    TE2 --> TQ2
```

## MassTransit Configuration

### Service Bus Topology

#### Exchange Configuration
- **Fanout Exchanges**: For broadcast events
- **Topic Exchanges**: For filtered routing
- **Direct Exchanges**: For command routing
- **Headers Exchanges**: For complex routing rules

#### Queue Configuration
- **Durable Queues**: For persistent messages
- **Priority Queues**: For critical operations
- **TTL Settings**: For message expiration
- **Dead Letter Exchanges**: For failed messages

### Consumer Configuration

```mermaid
graph LR
    subgraph "Consumer Groups"
        CG1[Application Module<br/>Consumers]
        CG2[Assessment Module<br/>Consumers]
        CG3[Certificate Module<br/>Consumers]
    end
    
    subgraph "Message Types"
        E1[ApplicationEvents]
        E2[AssessmentEvents]
        E3[CertificateEvents]
    end
    
    E1 --> CG2
    E1 --> CG3
    E2 --> CG3
    E3 --> CG1
```

### Retry and Error Handling

#### Retry Policies

1. **Immediate Retry**: 3 attempts with exponential backoff
2. **Delayed Retry**: After 5 minutes, 30 minutes, 2 hours
3. **Dead Letter Queue**: After all retries exhausted
4. **Manual Intervention**: For critical business processes

#### Error Handling Strategy

```mermaid
stateDiagram-v2
    [*] --> MessageReceived
    MessageReceived --> Processing
    Processing --> Success: No Error
    Processing --> ImmediateRetry: Transient Error
    ImmediateRetry --> Processing: Retry Count < 3
    ImmediateRetry --> DelayedRetry: Retry Count >= 3
    DelayedRetry --> Processing: After Delay
    DelayedRetry --> DeadLetter: Max Retries
    Success --> [*]
    DeadLetter --> ManualReview
    ManualReview --> [*]
```

## Event Sourcing Integration

### Event Store Architecture

```mermaid
graph TB
    subgraph "Write Path"
        AGG[Aggregate] --> ES[Event Store]
        ES --> EP[Event Publisher]
        EP --> MT[MassTransit]
    end
    
    subgraph "Read Path"
        ES2[Event Store] --> PROJ[Projections]
        PROJ --> RM[Read Models]
        RM --> API[Query API]
    end
    
    ES --> ES2
```

### Event Stream Design

#### Stream Naming Convention
- `{TenantId}-{AggregateType}-{AggregateId}`
- Example: `CAB123-Application-APP-2025-00001`

#### Event Metadata
- Event ID (UUID)
- Tenant ID
- Aggregate ID
- Event Type
- Timestamp
- User ID
- Correlation ID
- Causation ID

## Saga Management

### Saga Implementation Pattern

```mermaid
stateDiagram-v2
    [*] --> ApplicationReceived
    ApplicationReceived --> ReviewInProgress
    ReviewInProgress --> ApplicationApproved
    ApplicationApproved --> Stage1Scheduled
    Stage1Scheduled --> Stage1InProgress
    Stage1InProgress --> Stage1Completed
    Stage1Completed --> Stage2Scheduled: Positive
    Stage1Completed --> Terminated: Negative
    Stage2Scheduled --> Stage2InProgress
    Stage2InProgress --> Stage2Completed
    Stage2Completed --> CertificationDecision
    CertificationDecision --> CertificateIssued: Approved
    CertificationDecision --> Terminated: Rejected
    CertificateIssued --> [*]
    Terminated --> [*]
```

### Saga State Management
- Persistent state storage
- Compensation logic for failures
- Timeout handling
- Idempotent message handling

## Performance Optimization

### Message Batching
- Batch size limits (100 messages)
- Time-based flushing (100ms)
- Priority message bypass

### Parallelism Configuration
- Consumer concurrency limits
- Partition strategies for scalability
- Message ordering guarantees where required

### Caching Strategies
- Query result caching
- Projection caching
- Cache invalidation via events

## Monitoring and Observability

### Message Flow Monitoring

```mermaid
graph TB
    subgraph "Monitoring Stack"
        MT[MassTransit<br/>Metrics]
        RMQ[RabbitMQ<br/>Management]
        APM[Application<br/>Performance]
        LOG[Centralized<br/>Logging]
    end
    
    subgraph "Metrics"
        MSG[Message Rates]
        LAT[Latency]
        ERR[Error Rates]
        DLQ[Dead Letters]
    end
    
    MT --> MSG
    MT --> LAT
    RMQ --> ERR
    RMQ --> DLQ
```

### Key Metrics
- Message throughput per tenant
- Processing latency by message type
- Error rates and retry counts
- Queue depths and consumer lag
- Dead letter queue monitoring

### Distributed Tracing
- Correlation ID propagation
- Trace context headers
- End-to-end request tracking
- Performance bottleneck identification

## Security Considerations

### Message Security
- Message encryption in transit (TLS)
- Message signing for integrity
- Tenant isolation validation
- Access control per queue/exchange

### Audit Trail
- All messages logged with context
- Sensitive data masking
- Retention policies per message type
- Compliance with data regulations

## Migration and Evolution

### Versioning Strategy

#### Message Versioning
- Semantic versioning for contracts
- Backward compatibility requirements
- Version negotiation support
- Deprecation timeline (3 months minimum)

#### Evolution Patterns
1. **Adding Fields**: Always optional with defaults
2. **Removing Fields**: Mark deprecated first
3. **Changing Types**: New version required
4. **Renaming**: Map in consumer, deprecate old

### Module Extraction Process

```mermaid
graph LR
    subgraph "Phase 1: Monolith"
        M1[All Modules<br/>In-Process]
    end
    
    subgraph "Phase 2: Hybrid"
        M2[Core Modules]
        S1[Extracted Service]
    end
    
    subgraph "Phase 3: Distributed"
        S2[Service A]
        S3[Service B]
        S4[Service C]
    end
    
    M1 --> M2
    M2 --> S2
    S1 --> S3
    S1 --> S4
```

## Disaster Recovery

### Message Persistence
- All messages persisted to disk
- Replication across multiple nodes
- Regular backup of message stores
- Point-in-time recovery capability

### Failover Strategy
- Active-passive broker configuration
- Automatic failover with health checks
- Message replay from event store
- Zero message loss guarantee

---

*Document Version: 1.0*  
*Last Updated: 2025-01-06*  
*Review Frequency: Quarterly*

**Related Documents**:
- [Architecture Vision](./architecture-vision.md)
- [Modular Architecture](./modular-architecture.md)
- [Domain Model](./domain-model.md)
- [API Design Guidelines](./api-design-guidelines.md)