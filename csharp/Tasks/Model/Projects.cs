using System.Collections.Generic;
using Tasks.Actions;
using Tasks.Commands;
using Tasks.Infrastructure;

namespace Tasks.Model
{
    public sealed class Projects
    {
        private const string QUIT = "quit";
        private const string SHOW = "show";
        private const string ADD = "add";
        private const string CHECK = "check";
        private const string UNCHECK = "uncheck";
        private const string HELP = "help";
        private const string DEADLINE = "deadline";
        private const string TODAY = "today";

        private readonly IDictionary<string, IList<Task>> _projects =
            new Dictionary<string, IList<Task>>();

        private readonly IConsole _console;

        private long _lastId = 0;
        private string PROMPT = "> ";
        private readonly IProjectWriter _projectWriter = new ProjectWriter();
        private readonly ITaskWriter _taskWriter = new TaskWriter();


        public static void Main(string[] args)
        {
            new Projects(new RealConsole()).Run();
        }

        public Projects(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            while (true)
            {
                _console.Write(PROMPT);
                var command = _console.ReadLine();
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
                    var showAction = new ShowAction(_projects, _console, _projectWriter);
                    showAction.Execute();
                    break;
                case ADD:
                    var addAction = new AddAction(commandRest[1], _projects, NextId);
                    addAction.Execute();
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
                case DEADLINE:
                    var deadlineCommand = new DeadlineCommand(commandLine);
                    var deadlineAction = new DeadlineAction(deadlineCommand, _projects);
                    deadlineAction.Execute();
                    break;
                case TODAY:
                    var todayCommand = new TodayCommand(commandLine);
                    var todayAction = new TodayAction(_console, _projects, _taskWriter);
                    todayAction.Execute();
                    break;
                default:
                    Error(command);
                    break;
            }
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

            var identifiedTask = _projects.GetTaskById(id);

            if (identifiedTask == null)
            {
                _console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }

            identifiedTask.Done = done;
        }

        private void Help()
        {
            _console.WriteLine("Commands:");
            _console.WriteLine("  show");
            _console.WriteLine("  add project <project name>");
            _console.WriteLine("  add task <project name> <task description>");
            _console.WriteLine("  check <task ID>");
            _console.WriteLine("  uncheck <task ID>");
            _console.WriteLine();
        }

        private void Error(string command)
        {
            _console.WriteLine("I don't know what the command \"{0}\" is.", command);
        }

        private long NextId()
        {
            return ++_lastId;
        }
    }
}
