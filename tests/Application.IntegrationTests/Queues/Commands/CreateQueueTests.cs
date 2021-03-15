using System;
using System.Threading.Tasks;
using CleanArchitecture.Solution.Application.Common.Exceptions;
using CleanArchitecture.Solution.Application.Queues.Commands.CreateQueue;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Solution.Application.IntegrationTests.Queues.Commands
{
    using static Testing;

    public class CreateQueueTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateQueueCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public void ShouldFailWithAQueueNameLongerThan80()
        {
            // Arrange
            var longerName = new string('-', 81);
            var command = new CreateQueueCommand
            {
                Name = longerName
            };

            // Act
            Func<Task> action = async () =>
            {
                await SendAsync(command);
            };

            // Assert
            action.Should().Throw<ValidationException>()
                .And.Errors.Should().ContainKey(nameof(CreateQueueCommand.Name))
                .WhichValue.Should().BeEquivalentTo("Name must not exceed 80 characters.");
        }

        [Test]
        public void ShouldFailWithAQueueVisibilityTimeoutLongerThanOneMinute()
        {
            // Arrange
            var name = new string('-', 80);
            var command = new CreateQueueCommand
            {
                Name = name,
                VisibilityTimeouSeconds = 61
            };

            // Act
            Func<Task> action = async () =>
            {
                await SendAsync(command);
            };

            // Assert
            action.Should().Throw<ValidationException>()
                .And.Errors.Should().ContainKey(nameof(CreateQueueCommand.VisibilityTimeouSeconds))
                .WhichValue.Should().BeEquivalentTo("Timeout should be less than 1 minute.");
        }

        [Test]
        public async Task ShouldCreateQueue() 
        {
            // Arrange
            var command = new CreateQueueCommand
            {
                Name = "IntegrationTest",
                VisibilityTimeouSeconds = 12
            };

            // Act
            var queueUrl = await SendAsync(command);

            // Assert
            queueUrl.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            // Arrange
            // CreateQueueCommand and SendAsync

            // Act
            // SendAsync the same Command

            // Assert
            // Should Throw Validation Exception
        }
    }
}
