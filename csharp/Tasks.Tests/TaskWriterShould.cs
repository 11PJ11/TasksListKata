using System.Collections.Generic;
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

            _writer.WriteOneTask(task);

            _console.Received().WriteLine("    [x] 12345: taskDescription");
        }

        [Test]
        public void WriteManyTasks()
        {
            var task12345 = new Task(12345L, "taskDescription12345", true);
            var task54321 = new Task(54321L, "taskDescription54321", true);
            var project = new KeyValuePair<string,IList<Task>>
                ("projectName",new List<Task>{task12345, task54321});

            _writer.WriteTasksIn(project);

            _console.Received().WriteLine("    [x] 12345: taskDescription12345");
            _console.Received().WriteLine("    [x] 54321: taskDescription54321");
            _console.Received().WriteLine();
        }
    }
}