using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Solution.Application.Common.Interfaces
{
    public interface IQueueService
    {
        Task<string> CreateQueueAsync(string name, int visibilityTimeout, CancellationToken cancellationToken);
        // ListQueues
        // GetQueue
        // DeleteQueue
        // SendMessage
        // ReceiveMessage
    }
}
