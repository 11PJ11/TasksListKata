using NSubstitute;
using NUnit.Framework;

namespace Tasks
{
    [TestFixture]
    public sealed class TaskWriterShould
    {
        private IConsole _console;
        private TaskWriter _writer;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _writer = new TaskWriter(_console);
            
        }

        [Test]
        public void WriteATask()
        {
            var task = new Task(12345L, "taskDescription", true);

            _writer.WriteOneProjectTask(task);

            _console.Received().WriteLine("    [x] 12345: taskDescription");
        }
    }
}