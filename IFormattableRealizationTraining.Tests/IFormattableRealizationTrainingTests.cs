using System;
using NUnit.Framework;

namespace IFormattableRealizationTraining.Tests
{
    [TestFixture]
    public class IFormattableRealizationTrainingTests
    {
        [TestCase(
        "Alex",
        "+37800000",
        123567,
        "NCR",
        ExpectedResult = "Customer record: Alex, +37800000, 123567")]

        [TestCase(
        "Dmitry",
        "+1234235",
        56476,
        "N",
        ExpectedResult = "Customer record: Dmitry")]

        [TestCase(
        "Vlad",
        "+436565",
        111335656,
        "C",
        ExpectedResult = "Customer record: +436565")]

        [TestCase(
        "Vlad",
        "+436565",
        111335656,
        "R",
        ExpectedResult = "Customer record: 111335656")]
        public string ToString_Method_returns_expected_result(
            string name,
            string contactPhone,
            int revenue,
            string format)
        {
            decimal decRevenue = Convert.ToDecimal(revenue);
            var customer = new Customer(name, contactPhone, decRevenue);

            return customer.ToString(format);
        }

        [TestCase("", "124234", 342433)]
        [TestCase("Victor", "", 43435)]
        public void ToString_Method_throws_ArgumentException(
            string name,
            string contactPhone,
            int revenue)
        {
            decimal decRevenue = Convert.ToDecimal(revenue);

            Assert.That(
                () => new Customer(name, contactPhone, decRevenue),
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase("Victor", "124234", -33)]
        [TestCase("Victor", "345647", -43435)]
        [TestCase("Victor", "124234", -13)]
        [TestCase("Victor", "345647", -1)]
        [TestCase("Victor", "345647", -4000000)]
        public void ToString_Method_throws_ArgumentOutOfRangeException(
            string name,
            string contactPhone,
            int revenue)
        {
            decimal decRevenue = Convert.ToDecimal(revenue);

            Assert.That(
                () => new Customer(name, contactPhone, decRevenue),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}