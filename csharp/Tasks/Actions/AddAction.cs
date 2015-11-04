using System;
using System.Collections.Generic;
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
            var subcommandRest = _commandLine.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];

            if (subcommand == "project")
            {
                var projectName = subcommandRest[1];

                AddProject(projectName);
            }

            if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                var taskName = projectTask[0];
                var taskDescription = projectTask[1];

                AddTask(taskName, taskDescription);
            }
        }

        private void AddProject(string name)
        {
            _projects.Add(new Project(name));
        }

        private void AddTask(string projectName, string description)
        {
            var project = _projects.GetByName(projectName);
            var task = new Task(_nextId(), description, false);

            project.AddTask(task);

            //var projectTasks = _projects.GetTasksBy(project);
            //if (projectTasks == null)
            //{
            //    Console.WriteLine("Could not find a project with the name \"{0}\".", project);
            //    return;
            //}
            //var task = new Task(_nextId(), description, false);
            //projectTasks.Add(task);
        }

        
    }
}