using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingAllTheTaskWithSpecificDeadline
    {
        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheTasksExpiringOnTheDate()
        {
            var today = DateTime.Now;
            
            var moreDonutsTask = 
                new Task(new Id(123), "MORE DONUTS", false)
                {
                    Deadline = today
                };
            var secretProject = new Project("secret");
            secretProject.AddTask(moreDonutsTask);

            var solidTask =
                new Task(new Id(654), "SOLID", false);
            var normalProject = new Project("normal");
            normalProject.AddTask(solidTask);
            
            _projects.Add(secretProject);
            _projects.Add(normalProject);

            var expiringTasks = _projects.GetTasksWithDeadlineMatching(today);

            expiringTasks.Should().Contain(moreDonutsTask);
            expiringTasks.Should().NotContain(solidTask);
        }
    }
}