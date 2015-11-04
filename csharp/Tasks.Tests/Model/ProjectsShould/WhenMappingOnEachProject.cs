using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.ProjectsShould
{
    [TestFixture]
    public class WhenMappingOnEachProject
    {
        private Projects _projects;

        [SetUp]
        public void Setup()
        {
            _projects = new Projects();
        }

        [Test]
        public void ApplyTheFunctionToEveryProject()
        {
            Func<Project, string> getProjName = p => p.Name;
            _projects.Add(new Project("secret"));
            _projects.Add(new Project("normal"));
            _projects.Add(new Project("advanced"));

            var projectNames = _projects.Map(getProjName).ToList();

            projectNames.Should().Contain("secret");
            projectNames.Should().Contain("normal");
            projectNames.Should().Contain("advanced");
        }
    }
}