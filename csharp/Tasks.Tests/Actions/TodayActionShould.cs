using System;
using NSubstitute;
using NUnit.Framework;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    [TestFixture]
    public sealed class TodayActionShould
    {
        private IConsole _console;
        private IProjects _projects;
        private ITaskWriter _taskWriter;
        private TodayAction _todayAction;
        private Task[] _todaysTasks;
        private readonly string A_WRITABLE_TASK = "blah blah blah";
        private DateTime TODAY = Arg.Any<DateTime>();
        private Task A_TASK = Arg.Any<Task>();

        [SetUp]
        public void Setup()
        {
            _todaysTasks = new[] {
                new Task(new Id("123"),"SOLID",false){Deadline = DateTime.Now},
                new Task(new Id("456"),"DONUTS",false){Deadline = DateTime.Now}
            };

            _projects = Substitute.For<IProjects>();
            _console = Substitute.For<IConsole>();
            _taskWriter = Substitute.For<ITaskWriter>();
            _todayAction = new TodayAction(_console, _projects, _taskWriter);
        }

        [Test]
        public void ShowTheTasksThatHaveADeadlineSetForToday()
        {
            var TODAYS_TASKS_COUNT = _todaysTasks.Length;
            _projects.GetTasksWithDeadlineSetFor(TODAY)
                .Returns(_todaysTasks);
            _taskWriter.WriteOneTask(A_TASK)
                .Returns(A_WRITABLE_TASK);

            _todayAction.Execute();

            _console.Received(TODAYS_TASKS_COUNT).WriteLine(Arg.Any<string>());
        }
    }
}