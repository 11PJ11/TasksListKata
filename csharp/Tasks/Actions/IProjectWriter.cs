using System.Collections.Generic;
using Tasks.Model;

namespace Tasks.Actions
{
    public interface IProjectWriter
    {
        IEnumerable<string> WriteOneProject(Project project);
        IEnumerable<string> WriteAllProjects(Projects projects);
    }
}