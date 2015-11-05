using System;
using Tasks.Model;

namespace Tasks.Actions
{
    public sealed class AddTaskCommand
    {
        public string ProjectName { get; private set; }
        public Id TaskId { get; private set; }
        public string Description { get; private set; }
        public string TaskDescription { get; private set; }

        public AddTaskCommand(string commandLine, Func<long> nextId)
        {
            _nextId = nextId;
            var projectTask = GetProjectTask(commandLine);
            TaskId = GetTaskId(projectTask);
            ProjectName = GetProjectName(projectTask);
            TaskDescription = GetTaskDescription(projectTask);
        }

        private static string[] GetProjectTask(string commandLine)
        {
            var subcommandRest = commandLine.Split(" ".ToCharArray(), 3);
            var projectTask = subcommandRest[2].Split(" ".ToCharArray(), 3);
            return projectTask;
        }

        private static string GetProjectName(string[] projectTask)
        {
            return projectTask[0];
        }

        private static string GetTaskDescription(string[] projectTask)
        {
            return projectTask[1].Contains("'")
                ? projectTask[2]
                : projectTask[1] + " " + projectTask[2];
        }

        private Id GetTaskId(string[] projectTask)
        {
            return projectTask[1].Contains("'")
                ? new Id(projectTask[1].Replace("'",""))
                : new Id(_nextId());
        }

        private readonly Func<long> _nextId;
        private AddTaskCommand() {}
    }
}