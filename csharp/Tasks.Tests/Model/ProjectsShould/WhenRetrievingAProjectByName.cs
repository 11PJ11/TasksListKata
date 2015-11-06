using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenRetrievingAProjectByName
    {
        private const string SECRET_PROJECT = "secret";
        private const string NORMAL_PROJECT = "normal";

        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ReturnTheProject()
        {
            var secrest = new Project(SECRET_PROJECT);
            var normal = new Project(NORMAL_PROJECT);
            _projects.Add(secrest);
            _projects.Add(normal);

            var foundProject = _projects.GetProjectByName(SECRET_PROJECT);

            foundProject.Should().Be(secrest);
        }
    }
}