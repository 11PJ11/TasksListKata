using System.Collections.Generic;
using System.Linq;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    public class ProjectWriter : IProjectWriter
    {
        private ITaskWriter _tastWriter;

        public IEnumerable<string> WriteOneProject(KeyValuePair<string, IList<Task>> project)
        {
            _tastWriter = new TaskWriter();
            var writtenProject =
                new[]{
                         WriteProjectName(project)}
                    .Concat(_tastWriter.WriteTasksIn(project));
            
            return writtenProject;
        }

        private static string WriteProjectName(KeyValuePair<string, IList<Task>> project)
        {
            return project.Key;
        }

        public IEnumerable<string> WriteAllProjects(IDictionary<string, IList<Task>> projects)
        {
            return projects.SelectMany(WriteOneProject);
        }
    }
}