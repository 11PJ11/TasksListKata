using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Model
{
    public static class ProjectsExtensions
    {
        public static Task GetTaskById(
            this IDictionary<string, IList<Task>> projects, long id)
        {
            return projects
                .Select(project => 
                    project.Value
                    .FirstOrDefault(task => task.Id == id))
                .FirstOrDefault(task => task != null);
        }

        public static IEnumerable<Task> GetTasksWithDeadlineMatching(
            this IDictionary<string, IList<Task>> projects,
            DateTime deadline)
        {
            return projects
                .SelectMany(project => 
                    project.Value
                        .Where(task =>
                            task.Deadline.ToShortDateString() == deadline.ToShortDateString()));

        } 
    }
}