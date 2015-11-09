using System;
using System.Collections.Generic;

namespace Tasks.Model
{
    public interface IProjects
    {
        void Add(Project project);
        Project GetProjectByName(string projectName);
        Task GetTaskById(Id id);
        IEnumerable<Task> GetTasksWithDeadlineSetFor(DateTime date);
        IEnumerable<TResult> Map<TResult>(Func<Project, TResult> funcOnProject);
        bool Equals(object obj);
        int GetHashCode();
    }
}