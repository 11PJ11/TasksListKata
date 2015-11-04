using System.Collections.Generic;
using Tasks.Commands;
using Tasks.Model;

namespace Tasks.Actions
{
    public class DeadlineAction
    {
        private readonly Projects _projects;
        private readonly DeadlineCommand _deadlineCommand;

        public DeadlineAction(
            DeadlineCommand deadlineCommand, 
            Projects projects)
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