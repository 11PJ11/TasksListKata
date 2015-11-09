using System;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Tasks.Model.TasksShould
{
    [TestFixture]
    public class WhenRetrievingTasksByDeadline
    {
        private Tasks _tasks;
        private Fixture _fixture;
        private readonly DateTime DEADLINE = new DateTime(2015,11,6);
        private Task _expiringTask;
        private Task _aTask;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _fixture.Inject(new Id("123"));
            TheTasksHaveSomeTasks();
        }

        [Test, Timeout(500)]
        public void ReturnATasksCollectionContainingOnlyTheMatchingTasks()
        {
            var expiringTasks = new Tasks();
            expiringTasks.Add(_expiringTask);

            var foundTasks = _tasks.GetByDeadline(DEADLINE);

            foundTasks.Should().Be(expiringTasks);
        }

        private void TheTasksHaveSomeTasks()
        {
            _aTask = _fixture.Create<Task>();
            _expiringTask = CreateExpiringTask();
            _tasks = new Tasks();
            _tasks.Add(_aTask);
            _tasks.Add(_expiringTask);
        }

        private Task CreateExpiringTask()
        {
            var expiringTask = _fixture.Create<Task>();
            expiringTask.Deadline = DEADLINE;

            return expiringTask;
        }
    }
}