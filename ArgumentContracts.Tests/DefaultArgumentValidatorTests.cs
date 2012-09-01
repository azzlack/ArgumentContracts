﻿namespace ArgumentContracts.Tests
{
    using System;
    using System.Collections.Generic;

    using ArgumentContracts.Interfaces;
    using ArgumentContracts.Validators;

    using NUnit.Framework;

    [TestFixture]
    public class DefaultArgumentValidatorTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            Argument.Validators = new List<IArgumentValidator>()
                {
                    new StringArgumentValidator()
                };
        }

        [TestCase("some-string")]
        public void Require_WhenGivenValidArgument_ShouldReturnArgumentName(String s)
        {
            Argument.Require(() => s);

            Assert.Pass();
        }

        [TestCase(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Require_WhenGivenInvalidArgument_ShouldThrowException(String s)
        {
            Argument.Require(() => s);
        }
    }
}