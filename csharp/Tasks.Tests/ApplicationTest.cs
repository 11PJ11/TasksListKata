using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Tasks
{
    [TestFixture]
	public sealed class ApplicationTest
	{
		public const string PROMPT = "> ";

		private FakeConsole _console;
		private Thread _applicationThread;

		[SetUp]
		public void StartTheApplication()
		{
			_console = new FakeConsole();
			var taskList = new Projects(_console);
			_applicationThread = new Thread(taskList.Run);
			_applicationThread.Start();
		}

		[TearDown]
		public void KillTheApplication()
		{
			if (_applicationThread == null || 
               !_applicationThread.IsAlive)
			{
				return;
			}

			_applicationThread.Abort();
            
            if (_applicationThread.IsAlive)
			    throw new Exception("The application is still running.");
		}

		[Test, Timeout(500)]
		public void ItWorks()
		{
			Execute("show");

			Execute("add project secrets");
			Execute("add task secrets Eat more donuts.");
			Execute("add task secrets Destroy all humans.");

			Execute("show");
			ReadLines(
				"secrets",
				"    [ ] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				""
			);

			Execute("add project training");
			Execute("add task training Four Elements of Simple Design");
			Execute("add task training SOLID");
			Execute("add task training Coupling and Cohesion");
			Execute("add task training Primitive Obsession");
			Execute("add task training Outside-In TDD");
			Execute("add task training Interaction-Driven Design");

			Execute("check 1");
			Execute("check 2");
			Execute("check 3");
			Execute("check 5");
			Execute("check 6");
			Execute("uncheck 2");

			Execute("show");
			ReadLines(
				"secrets",
				"    [x] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				"",
				"training",
				"    [x] 3: Four Elements of Simple Design",
				"    [ ] 4: SOLID",
				"    [x] 5: Coupling and Cohesion",
				"    [x] 6: Primitive Obsession",
				"    [ ] 7: Outside-In TDD",
				"    [ ] 8: Interaction-Driven Design",
				""
			);

			Execute("quit");
		}

        [Test, Timeout(500)]
        public void ItShowsHelp()
        {
            Execute("help");

            ReadLines(
                "Commands:",
                "  show",
                "  add project <project name>",
                "  add task <project name> <task description>",
                "  check <task ID>",
                "  uncheck <task ID>",
                ""
            );

            Execute("quit");
        }

        [Test, Timeout(500)]
        public void ItShouldSetOptionalDeadlinesForTasks()
        {
            var today = DateTime.Now.ToShortDateString();
            Execute("add project training");
            Execute("add task training Four Elements of Simple Design");
            Execute("add task training SOLID");

            Execute(string.Format("deadline 1 {0}", today));

            Execute("today");
            ReadLines(
                "training",
				"    [ ] 4: SOLID",
                ""
            );

            Execute("quit");
        }

        [Test, Timeout(500)]
        public void ItShowsAnErrorMessageForUnknownCommand()
        {
            Execute("unknown");

            Read("I don't know what the command \"unknown\" is.");
            Read("\r\n");

            Execute("quit");
        }

		private void Execute(string command)
		{
			Read(PROMPT);
			Write(command);
		}

		private void Read(string expectedOutput)
		{
		    var actualOutput = _console.RetrieveOutput(expectedOutput.Length);
		    actualOutput.Should().Be(expectedOutput);
		}

		private void ReadLines(params string[] expectedOutput)
		{
			foreach (var line in expectedOutput)
			{
				Read(line + Environment.NewLine);
			}
		}

		private void Write(string input)
		{
            _console.SendInput(input + Environment.NewLine);
		}
	}
}
