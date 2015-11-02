namespace Tasks
{
    public class TaskWriter
    {
        private readonly IConsole _console;

        public TaskWriter(IConsole console)
        {
            _console = console;
        }

        public void WriteOneProjectTask(Task task)
        {
            var doneTask = (task.Done ? 'x' : ' ');
            var taskStatus = string.Format("    [{0}] {1}: {2}", doneTask, task.Id, task.Description);
            _console.WriteLine(taskStatus);
        } 
    }
}