using FluentAssertions;
using NUnit.Framework;
using Tasks.Model;

namespace Tasks.Infrastructure
{
    [TestFixture]
    public sealed class TaskWriterShould
    {
        private TaskWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new TaskWriter();
        }

        [Test]
        public void WriteATask()
        {
            var task = new Task(12345L, "taskDescription", true);

            var writtenTask = _writer.WriteOneTask(task);

            writtenTask.Should().Be("    [x] 12345: taskDescription");
        }

        [Test]
        public void WriteManyTasks()
        {
            var task12345 = new Task(12345, "taskDescription12345", true);
            var task54321 = new Task(54321, "taskDescription54321", true);
            var project = new Project("projectName");
            project.AddTask(task12345);
            project.AddTask(task54321);

            var writtenTasks = _writer.WriteTasksIn(project);

            var expectedWrittenTasks = 
                new[] {
                    "    [x] 12345: taskDescription12345",
                    "    [x] 54321: taskDescription54321",
                    ""};

            writtenTasks.ShouldAllBeEquivalentTo(expectedWrittenTasks);
        }
    }
}