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

        [Test]
        public void Complain_GivenSpacesPresentInId()
        {
            Action idCreation = () => new Id("a 123");

            idCreation
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("id value can't contain spaces");
        }

        [Test]
        public void Complain_GivenSpecialCharacterPresentInId()
        {
            Action idCreation = () => new Id("a%123");

            idCreation
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("id value can't contain special characters");
        }
    }
}