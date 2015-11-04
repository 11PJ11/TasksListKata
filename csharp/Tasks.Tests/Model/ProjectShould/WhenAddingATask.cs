using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Tasks.Model.ProjectShould
{
    [TestFixture]
    public class WhenAddingATask
    {
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void StoreTheTask()
        {
            var project = new Project("secret");
            var aTask = _fixture.Create<Task>();

            project.AddTask(aTask);

            project.Tasks.Should().Contain(aTask);
        }
    }
}
