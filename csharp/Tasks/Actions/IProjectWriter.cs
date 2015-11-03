using System.Collections.Generic;
using Tasks.Model;

namespace Tasks.Actions
{
    public interface IProjectWriter
    {
        IEnumerable<string> WriteOneProject(KeyValuePair<string, IList<Task>> project);
        IEnumerable<string> WriteAllProjects(IDictionary<string, IList<Task>> projects);
    }
}