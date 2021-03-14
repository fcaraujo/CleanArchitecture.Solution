# CleanArchitecture.Solution
A .NET Clean Architecture Application

## Installation

Install/run LocalStack + AWS Local

## Running 

http://localhost:4566
http://localhost:4566/health

```
λ awslocal sqs create-queue --queue-name MyDevQueue

λ awslocal sqs list-queues

λ awslocal sqs send-message --queue-url http://localhost:4566/000000000000/MyDevQueue --message-body "{\"ok\": true }"

λ awslocal sqs receive-message --queue-url http://localhost:4566/000000000000/MyDevQueue

λ awslocal sqs get-queue-attributes --queue-url http://localhost:4566/000000000000/MyDevQueue --attribute-names All
```