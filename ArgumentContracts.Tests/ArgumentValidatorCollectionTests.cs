namespace ArgumentContracts.Tests
{
    using System;
    using System.Linq;

    using ArgumentContracts.Validators;

    using NUnit.Framework;

    [TestFixture]
    public class ArgumentValidatorCollectionTests
    {
        private ArgumentValidatorCollection validators;

        [SetUp]
        public void SetUp()
        {
            this.validators = new ArgumentValidatorCollection();
        }

        [Test]
        public void Add_WhenValidatorDoesNotExist_ShouldIncrementValidatorTotal()
        {
            var originalCount = this.validators.Count;

            var v = new DefaultArgumentValidator<string>();

            this.validators.Add(v);

            Assert.That(this.validators.Count == originalCount + 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WhenValidatorExist_ShouldThrowException()
        {
            var v = new StringArgumentValidator();

            this.validators.Add(v);
        }

        [Test]
        public void Replace_WhenValidatorExist_ShouldReplaceValidator()
        {
            var v = this.validators.First();
            var n = new DefaultArgumentValidator<string>();

            this.validators.Replace(v.GetType(), n);

            Assert.That(this.validators.First().GetType() == n.GetType());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Replace_WhenValidatorDoesNotExist_ShouldThrowException()
        {
            var v = new DefaultArgumentValidator<string>();

            this.validators.Replace(v.GetType(), new StringArgumentValidator());
        }
    }
}