using System;
using System.Linq;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    public class TodayAction
    {
        private readonly IConsole _console;
        private readonly Projects _projects;
        private readonly ITaskWriter _taskWriter;

        public TodayAction(IConsole console, Projects projects, ITaskWriter taskWriter)
        {
            _console = console;
            _projects = projects;
            _taskWriter = taskWriter;
        }

        public void Execute()
        {
            var todaysTasks = _projects.GetTasksWithDeadlineMatching(DateTime.Now);
            var writtenTasks = todaysTasks.Select(task => _taskWriter.WriteOneTask(task));
            
            foreach (var writtenTask in writtenTasks)
            {
                _console.WriteLine(writtenTask);
            }
        }
    }
}