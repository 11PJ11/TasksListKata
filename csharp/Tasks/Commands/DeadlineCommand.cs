using System;
using Tasks.Model;

namespace Tasks.Commands
{
    public class DeadlineCommand
    {
        public DeadlineCommand(string commandLine)
        {
            var commandWithParams = commandLine.Split(' ');
            Name = commandWithParams[0]; ;
            TaskId = new Id(commandWithParams[1]);
            Deadline = DateTime.Parse(commandWithParams[2]); ;
        }

        public string Name { get; private set; }
        public Id TaskId { get; private set; }
        public DateTime Deadline { get; private set; }
    }
}