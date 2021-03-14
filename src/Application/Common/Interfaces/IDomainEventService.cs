using CleanArchitecture.Solution.Domain.Common;
using System.Threading.Tasks;

namespace CleanArchitecture.Solution.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
