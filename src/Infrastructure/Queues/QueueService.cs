using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using CleanArchitecture.Solution.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Solution.Infrastructure.Queues
{
    public class QueueService : IQueueService
    {
        private readonly ILogger _logger;
        private readonly IAmazonSQS _sqsClient;

        public QueueService(ILogger<QueueService> logger, IAmazonSQS sqsClient)
        {
            _logger = logger;
            _sqsClient = sqsClient;
        }

        public async Task<string> CreateQueueAsync(string name, int visibilityTimeout, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating queue called {name}.");

            var createRequest = new CreateQueueRequest
            {
                QueueName = name,
                Attributes = new Dictionary<string, string>
                {
                    { 
                        QueueAttributeName.VisibilityTimeout, 
                        TimeSpan.FromSeconds(visibilityTimeout).TotalSeconds.ToString() 
                    }
                }
            };

            var createResponse = await _sqsClient.CreateQueueAsync(createRequest, cancellationToken);

            var queueUrl = createResponse.QueueUrl;

            return queueUrl;
        }
    }
}
