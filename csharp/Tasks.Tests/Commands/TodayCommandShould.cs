using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Commands
{
    [TestFixture]
    public sealed class TodayCommandShould
    {
        [Test]
        public void CreateItselfFromACommandLine()
        {
            const string commandLine = "today";

            var todayCommand = new TodayCommand(commandLine);

            todayCommand.Name.Should().Be("today");
        }
    }
}