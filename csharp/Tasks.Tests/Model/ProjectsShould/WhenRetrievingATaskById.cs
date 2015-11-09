using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingATaskById
    {
        private readonly Id TASK_ID = new Id("123");
        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheTask_GivenWasAdded()
        {
            var task = new Task(TASK_ID, "MORE DONUTS", false);
            var project = new Project("secret");
            project.AddTask(task);
            _projects.Add(project);

            var foundTask = _projects.GetTaskById(TASK_ID);

            foundTask.Should().Be(task);

        }
    }
}