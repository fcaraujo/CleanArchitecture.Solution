# CleanArchitecture.Solution
A .NET Clean Architecture Application

## Installation

Install/run LocalStack + AWS Local

## Running 
After running a `docker-compose up` just double check the health check on http://localhost:4566.
You can also see the available services under http://localhost:4566/health.

### SQS
Some snippets to check if the container is running properly:

```
λ awslocal sqs create-queue --queue-name MyDevQueue

λ awslocal sqs list-queues

λ awslocal sqs send-message --queue-url http://localhost:4566/000000000000/MyDevQueue --message-body "{\"ok\": true }"

λ awslocal sqs receive-message --queue-url http://localhost:4566/000000000000/MyDevQueue

λ awslocal sqs get-queue-attributes --queue-url http://localhost:4566/000000000000/MyDevQueue --attribute-names All
```