using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Model
{
    public class Projects : IProjects
    {
        private readonly List<Project> _projects = new List<Project>();

        public void Add(Project project)
        {
            _projects.Add(project);
        }

        public Project GetProjectByName(string projectName)
        {
            return _projects.Find(project => project.Name == projectName);
        }

        public Task GetTaskById(Id id)
        {
            return _projects
                .SelectMany(p =>
                    p.Tasks.Where(t => t.Id.Equals(id)))
                .First();
        }

        //TODO: move the filter closer to Tasks
        public IEnumerable<Task> GetTasksWithDeadlineSetFor(DateTime date)
        {
            return _projects.SelectMany(project =>
                    project.Tasks.Where(task => 
                        task.Deadline.ToShortDateString() == date.ToShortDateString()));
        }

        public IEnumerable<TResult> Map<TResult>(
            Func<Project, TResult> funcOnProject)
        {
            return _projects.Select(funcOnProject);
        }

        protected bool Equals(Projects other)
        {
            return _projects.Count == other._projects.Count &&
                   _projects.All(prj => other._projects.Contains(prj));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Projects)obj);
        }

        public override int GetHashCode()
        {
            return (_projects != null ? _projects.GetHashCode() : 0);
        }
    }
}