namespace FabrikamFiber.Web.Tests.Helpers
{
    using System;
    using FabrikamFiber.Web.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class GuardTest
    {
        [Test]
        [NUnit.Framework.ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNull()
        {
            Guard.ThrowIfNull(null, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNull()
        {
            Guard.ThrowIfNull("this is not null", "value");
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNullOrEmpty()
        {
            Guard.ThrowIfNullOrEmpty(string.Empty, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNullOrEmpty()
        {
            Guard.ThrowIfNullOrEmpty("not null or empty", "value");
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItShouldThrowExceptionIfArgumentIsLesserThanZero()
        {
            Guard.ThrowIfLesserThanZero(-1, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotLesserThanZero()
        {
            Guard.ThrowIfLesserThanZero(1, "value");
        }
    }
}
