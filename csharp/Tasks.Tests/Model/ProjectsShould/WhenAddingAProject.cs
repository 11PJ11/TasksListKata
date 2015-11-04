using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public sealed class WhenAddingAProject
    {
        private Projects _projects;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _projects = new Projects();
        }

        [Test]
        public void AddAProject()
        {
            var expProjects = new Projects();
            var aProject = _fixture.Create<Project>();
            expProjects.Add(aProject);

            _projects.Add(aProject);

            _projects.Should().Be(expProjects);
        }
    }
}