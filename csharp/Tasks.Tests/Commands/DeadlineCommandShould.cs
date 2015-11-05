using System;
using FluentAssertions;
using NUnit.Framework;
using Tasks.Model;

namespace Tasks.Commands
{
    [TestFixture]
    public sealed class DeadlineCommandShould
    {
        [Test]
        public void CreateItselfOutOfACommandLine()
        {
            const string commandLine = "deadline a-123 05/11/2015";

            var deadlineCommand = new DeadlineCommand(commandLine);

            deadlineCommand.Name.Should().Be("deadline");
            deadlineCommand.TaskId.Should().Be(new Id("a-123"));
            deadlineCommand.Deadline.Should().Be(new DateTime(2015, 11, 5));
        }
    }
}