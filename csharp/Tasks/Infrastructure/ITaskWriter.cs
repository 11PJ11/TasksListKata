using System.Collections.Generic;
using Tasks.Model;

namespace Tasks.Infrastructure
{
    public interface ITaskWriter
    {
        string WriteOneTask(Task task);
        IEnumerable<string> WriteTasksIn(Project project);
    }
}