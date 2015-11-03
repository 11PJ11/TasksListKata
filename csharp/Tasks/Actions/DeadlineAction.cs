using System.Collections.Generic;
using Tasks.Commands;
using Tasks.Model;

namespace Tasks.Actions
{
    public class DeadlineAction
    {
        private readonly IDictionary<string, IList<Task>> _projects;
        private readonly DeadlineCommand _deadlineCommand;

        public DeadlineAction(
            DeadlineCommand deadlineCommand, 
            IDictionary<string, IList<Task>> projects)
        {
            _deadlineCommand = deadlineCommand;
            _projects = projects;
        }

        public void Execute()
        {
            var task = _projects.GetTaskById(_deadlineCommand.TaskId);

            task.Deadline = _deadlineCommand.Deadline;
        }
    }
}