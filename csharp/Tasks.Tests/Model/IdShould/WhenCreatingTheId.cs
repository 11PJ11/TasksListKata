using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.IdShould
{
    [TestFixture]
    public class WhenCreatingTheId
    {
        [Test]
        public void Complain_GivenNullValue()
        {
            Action idCreation = () => new Id(null);

            idCreation.ShouldThrow<ArgumentNullException>();
        }
    }
}