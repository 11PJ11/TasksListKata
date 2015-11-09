using System;
using System.Linq;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    public class TodayAction
    {
        private readonly IConsole _console;
        private readonly IProjects _projects;
        private readonly ITaskWriter _taskWriter;

        public TodayAction(
            IConsole console, 
            IProjects projects, 
            ITaskWriter taskWriter)
        {
            _console = console;
            _projects = projects;
            _taskWriter = taskWriter;
        }

        public void Execute()
        {
            var todaysTasks = _projects.GetTasksWithDeadlineSetFor(DateTime.Now);
            var writableTasks = todaysTasks.Select(task => _taskWriter.WriteOneTask(task));
            
            foreach (var writableTask in writableTasks)
            {
                _console.WriteLine(writableTask);
            }
        }
    }
}