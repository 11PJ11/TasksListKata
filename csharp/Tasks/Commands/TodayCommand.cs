namespace Tasks.Commands
{
    public class TodayCommand
    {
        public TodayCommand(string commandLine)
        {
            Name = commandLine;
        }

        public string Name { get; private set; }
    }
}