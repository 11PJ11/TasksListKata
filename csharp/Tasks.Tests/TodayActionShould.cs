using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Tasks.Actions;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks
{
    [TestFixture]
    public sealed class TodayActionShould
    {
        private IConsole _console;
        private ITaskWriter _taskWriter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _taskWriter = new TaskWriter();
        }

        [Test]
        public void ShowTheTasksThatHaveADeadlineSetForToday()
        {
            var solidTask = new Task(1, "SOLID", false) {Deadline = DateTime.Now};
            var donutsTask = new Task(2, "DONUTS", false) {Deadline = DateTime.Now};
            var takeOverTask = new Task(3, "TAKE OVER THE WORLD", false);

            var projects = 
                new Dictionary<string, IList<Task>>
                {
                    {"training",new List<Task>{solidTask}},
                    {"secret",new List<Task>{donutsTask, takeOverTask}}
                };
            var todayAction = new TodayAction(_console, projects, _taskWriter);

            todayAction.Execute();

            _console.Received().WriteLine("    [ ] 1: SOLID");
            _console.Received().WriteLine("    [ ] 2: DONUTS");
        }
    }
}