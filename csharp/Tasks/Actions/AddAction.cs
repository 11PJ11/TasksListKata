using System;
using Tasks.Model;

namespace Tasks.Actions
{
    public class AddAction : Action
    {
        private readonly string _commandLine;
        private readonly Projects _projects;
        private readonly Func<long> _nextId;

        public AddAction(
            string commandLine, 
            Projects projects, 
            Func<long> nextId)
        {
            _commandLine = commandLine;
            _projects = projects;
            _nextId = nextId;
        }

        public override void Execute()
        {
            var subcommandRest = _commandLine.Split(" ".ToCharArray(), 3);
            var subcommand = subcommandRest[1];

            if (subcommand == "project")
            {
                var projectName = subcommandRest[2];

                AddProject(projectName);
            }

            if (subcommand == "task")
            {
                var addTaskCommand = new AddTaskCommand(_commandLine, _nextId);
                AddTask(addTaskCommand);
            }
        }

        private void AddProject(string name)
        {
            _projects.Add(new Project(name));
        }

        private void AddTask(AddTaskCommand addTaskCommand)
        {
            var task = new Task(addTaskCommand.TaskId, addTaskCommand.TaskDescription, false);
            var project = _projects.GetProjectByName(addTaskCommand.ProjectName);
            project.AddTask(task);
        }
    }
}