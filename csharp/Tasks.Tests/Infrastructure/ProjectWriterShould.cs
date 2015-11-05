using FluentAssertions;
using NUnit.Framework;
using Tasks.Actions;
using Tasks.Model;

namespace Tasks.Infrastructure
{
    [TestFixture]
    public sealed class ProjectWriterShould
    {
        private ProjectWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new ProjectWriter();
        }

        [Test]
        public void WriteOneProject()
        {
            var task = new Task(new Id(1), "SOLID", false);
            var project = new Project("training");
            project.AddTask(task);
            var expectedWrittenProject =
                new[]
                {
                    "training",
                    "    [ ] 1: SOLID",
                    ""
                };

            var writtenProject = _writer.WriteOneProject(project);

            writtenProject.ShouldBeEquivalentTo(expectedWrittenProject);
        }

        [Test]
        public void WriteManyProjects()
        {
            var solidTask = new Task(new Id(1), "SOLID", false);
            var trainingProject = new Project("training");
            trainingProject.AddTask(solidTask);

            var donutsTask = new Task(new Id(2), "DONUTS", false);
            var secretProject = new Project("secret");
            secretProject.AddTask(donutsTask);

            var projects = new Projects();
            projects.Add(trainingProject);
            projects.Add(secretProject);
            
            var expectedWrittenProject =
                new[]
                {
                    "training",
                    "    [ ] 1: SOLID",
                    "",
                    "secret",
                    "    [ ] 2: DONUTS",
                    ""
                };


            var writtenProject = _writer.WriteAllProjects(projects);

            writtenProject.ShouldBeEquivalentTo(expectedWrittenProject);
        }
    }
}