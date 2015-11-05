using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.IdShould
{
    [TestFixture]
    public class WhenComparingToAnotherId
    {
        [Test]
        public void ReturnsFalseGivenDifferentTypes()
        {
            var id = new Id(123);
            var otherId = new Id(new Object());

            id.Should().NotBe(otherId);
        }

        [Test]
        public void ReturnsFalseGivenSameTypeAndDifferentValues()
        {
            var id = new Id(123);
            var otherId = new Id(456);

            id.Should().NotBe(otherId);
        }

        [Test]
        public void ReturnsTureGivenSameTypeAndSameValues()
        {
            var guid = Guid.NewGuid();
            var id = new Id(guid);
            var otherId = new Id(guid);

            id.Should().Be(otherId);
        }
    }
}
