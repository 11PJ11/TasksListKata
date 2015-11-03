using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tasks.Actions;
using Tasks.Commands;
using Tasks.Model;

namespace Tasks
{
    [TestFixture]
    public sealed class DeadlineActionShould
    {
        [Test]
        public void ItShouldSetTheDeadlineForATask()
        {
            var task = new Task(123, "the description", false);
            var projects = new Dictionary<string, IList<Task>>
                           {
                               {"a project", new []{task}}
                           };
            var deadlineCommand = new DeadlineCommand("deadline 123 05/11/2015");
            var deadlineAction = new DeadlineAction(deadlineCommand, projects);
            var expDeadline = new DateTime(2015, 11, 5);

            deadlineAction.Execute();

            task.Deadline.Should().Be(expDeadline);
        }
    }
}