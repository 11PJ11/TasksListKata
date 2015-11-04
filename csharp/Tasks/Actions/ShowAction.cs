using System.Collections.Generic;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    public class ShowAction : Action
    {
        private readonly IProjectWriter _projectWriter;
        private readonly Projects _projects;
        private readonly IConsole _console;

        public ShowAction(Projects projects, IConsole console, IProjectWriter projectWriter)
        {
            _projects = projects;
            _console = console;
            _projectWriter = projectWriter;
        }

        public override void Execute()
        {
            var writtenProjects = _projectWriter.WriteAllProjects(_projects);
            foreach (var writtenProject in writtenProjects)
            {
                _console.WriteLine(writtenProject);
            }
        }
    }
}