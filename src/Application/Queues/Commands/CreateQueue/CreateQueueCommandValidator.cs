using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Solution.Application.Queues.Commands.CreateQueue
{
    public class CreateQueueCommandValidator : AbstractValidator<CreateQueueCommand>
    {
        public CreateQueueCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name must not exceed 80 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");

            RuleFor(v => v.VisibilityTimeouSeconds)
                .NotEmpty().WithMessage("Timeout is required.")
                .LessThan(60).WithMessage("Timeout should be less than 1 minute.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            // TODO inject and query for a queue with the name
            var isValid = true;
            return isValid;
        }
    }
}
