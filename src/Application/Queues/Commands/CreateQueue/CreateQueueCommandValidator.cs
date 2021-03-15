using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Solution.Application.Queues.Commands.CreateQueue
{
    public class CreateQueueCommandValidator : AbstractValidator<CreateQueueCommand>
    {
        public CreateQueueCommandValidator()
        {
            // Name field
            const string nameField = nameof(CreateQueueCommand.Name);
            const int nameMaxCharacters = 80;

            // Timeout field
            const string timeoutField = nameof(CreateQueueCommand.VisibilityTimeouSeconds);
            const int visibilityTimeoutSeconds = 60;

            RuleFor(v => v.Name)
                .NotEmpty()
                    .WithMessage($"{nameField} is required.")
                .MaximumLength(nameMaxCharacters)
                    .WithMessage($"{nameField} must not exceed {nameMaxCharacters} characters.")
                .MustAsync(BeUniqueName)
                    .WithMessage($"The specified queue {nameField} already exists.");

            RuleFor(v => v.VisibilityTimeouSeconds)
                .NotEmpty()
                    .WithMessage($"{timeoutField} is required.")
                .LessThan(visibilityTimeoutSeconds)
                    .WithMessage($"{timeoutField} should be less than {visibilityTimeoutSeconds} seconds.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            // TODO inject and query for a queue with the name
            var isValid = true;
            return isValid;
        }
    }
}
