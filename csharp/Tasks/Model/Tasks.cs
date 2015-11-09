
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Model
{
    public sealed class Tasks : ITasks
    {
        private readonly IList<Task> _tasks = new List<Task>();
 
        public void Add(Task task)
        {
            _tasks.Add(task);
        }

        private bool Equals(Tasks other)
        {
            return _tasks.Count == other._tasks.Count &&
                   _tasks.All(task => other._tasks.Contains(task));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Tasks && Equals((Tasks) obj);
        }

        public override int GetHashCode()
        {
            return (_tasks != null ? _tasks.GetHashCode() : 0);
        }
    }
}