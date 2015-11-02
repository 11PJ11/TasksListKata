using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public sealed class Projects
    {
        private const string QUIT = "quit";
        private const string SHOW = "show";
        private const string ADD = "add";
        private const string CHECK = "check";
        private const string UNCHECK = "uncheck";
        private const string HELP = "help";

        private readonly IDictionary<string, IList<Task>> _projects =
            new Dictionary<string, IList<Task>>();

        private readonly IConsole console;

        private long _lastId = 0;
        private string PROMPT = "> ";


        public static void Main(string[] args)
        {
            new Projects(new RealConsole()).Run();
        }

        public Projects(IConsole console)
        {
            this.console = console;
        }

        public void Run()
        {
            while (true)
            {
                console.Write(PROMPT);
                var command = console.ReadLine();
                if (command == QUIT)
                {
                    break;
                }
                Execute(command);
            }
        }

        private void Execute(string commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var command = commandRest[0];
            switch (command)
            {
                case SHOW:
                    Show();
                    break;
                case ADD:
                    Add(commandRest[1]);
                    break;
                case CHECK:
                    Check(commandRest[1]);
                    break;
                case UNCHECK:
                    Uncheck(commandRest[1]);
                    break;
                case HELP:
                    Help();
                    break;
                default:
                    Error(command);
                    break;
            }
        }

        private void Show()
        {
            WriteAllProjects();
        }

        private void WriteAllProjects()
        {
            foreach (var project in _projects)
            {
                WriteOneProject(project);
            }
        }

        private void WriteOneProject(KeyValuePair<string, IList<Task>> project)
        {
            WriteProjectName(project.Key);
            WriteAllProjectTasks(project.Value);
        }

        private void WriteProjectName(string projectName)
        {
            console.WriteLine(projectName);
        }

        private void WriteAllProjectTasks(IList<Task> projectTasks)
        {
            var taskWriter = new TaskWriter(console);
            foreach (var task in projectTasks)
            {
                taskWriter.WriteOneProjectTask(task);
            }
            console.WriteLine();
        }

        private void Add(string commandLine)
        {
            var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            if (subcommand == "project")
            {
                AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                AddTask(projectTask[0], projectTask[1]);
            }
        }

        private void AddProject(string name)
        {
            _projects[name] = new List<Task>();
        }

        private void AddTask(string project, string description)
        {
            IList<Task> projectTasks = _projects[project];
            if (projectTasks == null)
            {
                Console.WriteLine("Could not find a project with the name \"{0}\".", project);
                return;
            }
            var task = new Task(NextId(),description, false);
            projectTasks.Add(task);
        }

        private void Check(string idString)
        {
            SetDone(idString, true);
        }

        private void Uncheck(string idString)
        {
            SetDone(idString, false);
        }

        private void SetDone(string idString, bool done)
        {
            int id = int.Parse(idString);
            var identifiedTask = _projects
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();
            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", id);
                return;
            }

            identifiedTask.Done = done;
        }

        private void Help()
        {
            console.WriteLine("Commands:");
            console.WriteLine("  show");
            console.WriteLine("  add project <project name>");
            console.WriteLine("  add task <project name> <task description>");
            console.WriteLine("  check <task ID>");
            console.WriteLine("  uncheck <task ID>");
            console.WriteLine();
        }

        private void Error(string command)
        {
            console.WriteLine("I don't know what the command \"{0}\" is.", command);
        }

        private long NextId()
        {
            return ++_lastId;
        }
    }
}
