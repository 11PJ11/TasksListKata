using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Model
{
    public static class ProjectsExtensions
    {
        public static Task GetTaskById(this IEnumerable<Project> projects, long id)
        {
            return projects
                .Select(project => 
                    project.Tasks
                    .FirstOrDefault(task => task.Id == id))
                .FirstOrDefault(task => task != null);
        }

        public static IEnumerable<Task> GetTasksWithDeadlineMatching(this IEnumerable<Project> projects, DateTime deadline)
        {
            return projects
                .SelectMany(project => 
                    project.Tasks
                        .Where(task =>
                            task.Deadline.ToShortDateString() == deadline.ToShortDateString()));

        } 
    }
}