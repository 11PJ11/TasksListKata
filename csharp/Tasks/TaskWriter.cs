using System.Collections.Generic;

namespace Tasks
{
    public interface ITaskWriter
    {
        void WriteOneTask(Task task);
        void WriteTasksIn(KeyValuePair<string, IList<Task>> project);
    }

    public class TaskWriter : ITaskWriter
    {
        private readonly IConsole _console;

        public TaskWriter(IConsole console)
        {
            _console = console;
        }

        public void WriteOneTask(Task task)
        {
            var doneTask = (task.Done ? 'x' : ' ');
            var taskStatus = string.Format("    [{0}] {1}: {2}", doneTask, task.Id, task.Description);
            _console.WriteLine(taskStatus);
        }

        public void WriteTasksIn(KeyValuePair<string, IList<Task>> project)
        {
            foreach (var task in project.Value)
            {
                WriteOneTask(task);
            }
            _console.WriteLine();
        }
    }
}