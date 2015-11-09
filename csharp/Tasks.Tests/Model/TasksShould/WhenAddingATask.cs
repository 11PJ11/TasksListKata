using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Tasks.Model.TasksShould
{
    [TestFixture]
    public class WhenAddingATask
    {
        private Tasks _tasks;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _fixture.Inject(new Id("123"));
            _tasks = new Tasks();
        }

        [Test, Timeout(500)]
        public void StoreTheTask()
        {
            var aTask = _fixture.Create<Task>();
            var expTasks = new Tasks();
            expTasks.Add(aTask);
            
            _tasks.Add(aTask);

            _tasks.Should().Be(expTasks);
        }
    }
}
