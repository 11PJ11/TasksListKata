using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Tasks.Model.ProjectShould
{
    [TestFixture]
    public class WhenAddingATask
    {
        private readonly Project _project = new Project("secret");
        private Task A_TASK;

        [Test]
        public void StoreTheTask()
        {
            A_TASK = Arg.Any<Task>();
            
            _project.AddTask(A_TASK);

            _project.Tasks.Should().Contain(A_TASK);
        }
    }
}
