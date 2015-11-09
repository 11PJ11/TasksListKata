using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Tasks.Model.ProjectShould
{
    [TestFixture]
    public class WhenAddingATask
    {
        private readonly ITasks _tasks = Substitute.For<ITasks>();
        private Project _project;
        private Task A_TASK = new Task(new Id("123"), "a task", false);

        [SetUp]
        public void Setup()
        {
            _project = new Project("secret", _tasks);
        }

        [Test]
        public void StoreTheTask()
        {
            _project.AddTask(A_TASK);

            _project.Tasks.Should().Contain(A_TASK);
            _tasks.Received().Add(A_TASK);
        }
    }
}
