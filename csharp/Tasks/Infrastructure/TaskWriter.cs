using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Model;

namespace Tasks.Infrastructure
{
    public class TaskWriter : ITaskWriter
    {
        public string WriteOneTask(Task task)
        {
            var doneTask = (task.Done ? 'x' : ' ');
            var taskStatus = String.Format(
                "    [{0}] {1}: {2}", 
                doneTask, 
                task.Id, 
                task.Description);
            
            return taskStatus;
        }

        public IEnumerable<string> WriteTasksIn(Project project)
        {
            return project.Tasks
                .Select(WriteOneTask)
                .Concat(new []{string.Empty});
        }
    }
}