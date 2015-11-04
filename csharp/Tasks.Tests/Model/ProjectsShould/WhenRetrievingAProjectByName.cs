using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingAProjectByName
    {
        private const string PROJECT_NAME = "secret";
        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheProject()
        {
            var project = new Project(PROJECT_NAME);
            _projects.Add(project);

            var foundProject = _projects.GetByName(PROJECT_NAME);

            foundProject.Should().Be(project);
        }
    }
}