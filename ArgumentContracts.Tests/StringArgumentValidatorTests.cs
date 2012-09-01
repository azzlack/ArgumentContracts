namespace ArgumentContracts.Tests
{
    using System;
    using System.Collections.Generic;

    using ArgumentContracts.Core.Interfaces;
    using ArgumentContracts.Validators;

    using NUnit.Framework;

    [TestFixture]
    public class StringArgumentValidatorTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            ArgumentValidators.Instance.Add(new StringArgumentValidator());
        }

        [TestCase("some-id")]
        public void Require_WhenGivenValidArgument_ShouldReturnArgumentName(string id)
        {
            Argument.Require(() => id);

            Assert.Pass();
        }

        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Require_WhenGivenInvalidArgument_ShouldThrowException(string id)
        {
            Argument.Require(() => id);
        }
    }
}
