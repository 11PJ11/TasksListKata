using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingAllTheTaskWithSpecificDeadline
    {
        private static readonly DateTime TODAY = DateTime.Now;
        private Projects _projects;
        private readonly Task _moreDonutsTask = new Task(new Id("123"), "MORE DONUTS", false) { Deadline = TODAY };
        private readonly Task _solidTask = new Task(new Id("654"), "SOLID", false);
        private readonly Project _secretProject = new Project("secret");
        private readonly Project _normalProject = new Project("normal");

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheTasksExpiringOnTheDate()
        {
            _secretProject.AddTask(_moreDonutsTask);
            _normalProject.AddTask(_solidTask);
            _projects.Add(_secretProject);
            _projects.Add(_normalProject);

            var expiringTasks = _projects.GetTasksWithDeadlineSetFor(TODAY);

            expiringTasks.Should().Contain(_moreDonutsTask);
            expiringTasks.Should().NotContain(_solidTask);
        }
    }
}