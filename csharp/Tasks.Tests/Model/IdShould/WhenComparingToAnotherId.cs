using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Model.IdShould
{
    [TestFixture]
    public class WhenComparingToAnotherId
    {
        [Test]
        public void ReturnsFalse_GivenDifferentTypes()
        {
            var id = new Id(123);
            var otherId = new Id(new Object());

            id.Should().NotBe(otherId);
        }

        [Test]
        public void ReturnsFalse_GivenSameTypeAndDifferentValues()
        {
            var id = new Id(123);
            var otherId = new Id(456);

            id.Should().NotBe(otherId);
        }

        //[Test]
        //public void ReturnsTrue_GivenDifferentTypesButSameSerializedRepresentation()
        //{
        //    var id = new Id(123);
        //    var otherId = new Id("123");

        //    id.Should().Be(otherId);
        //}

        [Test]
        public void ReturnsTrue_GivenSameTypeAndSameValues()
        {
            var guid = Guid.NewGuid();
            var id = new Id(guid);
            var otherId = new Id(guid);

            id.Should().Be(otherId);
        }
    }
}