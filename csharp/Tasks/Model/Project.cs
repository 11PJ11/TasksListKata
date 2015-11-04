using System.Collections.Generic;
using System.Linq;

namespace Tasks.Model
{
    public class Project
    {
        public readonly string Name = "";
        public readonly IList<Task> Tasks = new List<Task>();

        private Project() { }

        public Project(string name)
        {
            Name = name;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        protected bool Equals(Project other)
        {
            return string.Equals(Name, other.Name) &&
                   Tasks.Count == other.Tasks.Count &&
                   Tasks.All(task => other.Tasks.Contains(task));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Project) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ (Tasks != null ? Tasks.GetHashCode() : 0);
            }
        }
    }
}