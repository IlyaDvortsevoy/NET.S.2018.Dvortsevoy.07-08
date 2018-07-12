using IFormattableRealizationTraining;
using NUnit.Framework;

namespace IFormatProviderRealization.Tests
{
    [TestFixture]
    public class IFormatProviderRealizationTests
    {
        [Test, TestCaseSource(typeof(Data), "TestCases")]
        public string Format_Method_of_CustomerDetailedFormatter_class_returns_proper_result(
                Customer customer)
        {
            return string.Format(new CustomerDetailedFormatter(), "{0}", customer);
        }
    }
}