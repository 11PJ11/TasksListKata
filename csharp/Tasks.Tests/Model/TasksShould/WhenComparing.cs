using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Tasks.Model.TasksShould
{
    [TestFixture]
    public class WhenComparing
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
        public void ReturnFalseGivenDifferentElementsInCollection()
        {
            var aTask = _fixture.Create<Task>();
            var expTasks = new Tasks();

            _tasks.Add(aTask);

            _tasks.Should().NotBe(expTasks);
        }
    }
}