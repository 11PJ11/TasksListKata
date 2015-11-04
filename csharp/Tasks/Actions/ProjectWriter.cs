using System.Collections.Generic;
using System.Linq;
using Tasks.Infrastructure;
using Tasks.Model;

namespace Tasks.Actions
{
    public class ProjectWriter : IProjectWriter
    {
        private ITaskWriter _tastWriter;

        public IEnumerable<string> WriteOneProject(Project project)
        {
            _tastWriter = new TaskWriter();
            var writtenProject =
                new[]{project.Name}
                    .Concat(_tastWriter.WriteTasksIn(project));
            
            return writtenProject;
        }

        public IEnumerable<string> WriteAllProjects(Projects projects)
        {
            return projects.Map(WriteOneProject)
                .SelectMany(x => x.ToList());
        }
    }
}