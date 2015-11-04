using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingATaskById
    {
        private const int TASK_ID = 123;
        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheTask()
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