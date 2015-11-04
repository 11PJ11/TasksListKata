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

            var trainingProject = new Project("training");
            trainingProject.AddTask(solidTask);

            var secretProject = new Project("secret");
            secretProject.AddTask(donutsTask);
            secretProject.AddTask(takeOverTask);
            
            var projects = new Projects();
            projects.Add(trainingProject);
            projects.Add(secretProject);

            var todayAction = new TodayAction(_console, projects, _taskWriter);

            todayAction.Execute();

            _console.Received().WriteLine("    [ ] 1: SOLID");
            _console.Received().WriteLine("    [ ] 2: DONUTS");
        }
    }
}