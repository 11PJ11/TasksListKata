using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tasks.Actions;
using Tasks.Model;

namespace Tasks
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
            var project = new KeyValuePair<string, IList<Task>>
            ("training", new[] { new Task(1, "SOLID", false) });
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
            var projects =
                new Dictionary<string, IList<Task>>
                {
                    { "training", new[] { new Task(1, "SOLID", false) } },
                    { "secret", new[] { new Task(2, "DONUTS", false) } }
                };

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