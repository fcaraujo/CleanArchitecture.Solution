using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Solution.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Solution.Application.Queues.Commands.CreateQueue
{
    public class CreateQueueCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int VisibilityTimeouSeconds { get; set; }
    }

    public class CreateQueueCommandHandler : IRequestHandler<CreateQueueCommand, string>
    {
        private readonly IQueueService _queueService;

        public CreateQueueCommandHandler(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task<string> Handle(CreateQueueCommand request, CancellationToken cancellationToken)
        {
            var res = await _queueService.CreateQueueAsync(request.Name, request.VisibilityTimeouSeconds, cancellationToken);

            return res;
        }
    }
}
