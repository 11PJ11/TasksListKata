using System;
using FluentAssertions;
using NUnit.Framework;
using Tasks.Commands;
using Tasks.Model;

namespace Tasks.Actions
{
    [TestFixture]
    public sealed class DeadlineActionShould
    {
        [Test]
        public void ItShouldSetTheDeadlineForATask()
        {
            var task = new Task(new Id("123"), "the description", false);
            var project = new Project("a project");
            project.AddTask(task);
            var projects = new Projects();
            projects.Add(project);
                
            var deadlineCommand = new DeadlineCommand("deadline 123 05/11/2015");
            var deadlineAction = new DeadlineAction(deadlineCommand, projects);
            var expDeadline = new DateTime(2015, 11, 5);

            deadlineAction.Execute();

            task.Deadline.Should().Be(expDeadline);
        }
    }
}