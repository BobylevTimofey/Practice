using NUnit.Framework;
using Practice.Models;
using Practice.Services.AdditionalInfoServices;
using Practice.Services.AdditionalInfoServices.Sortings;

namespace Practice.Tests
{
    [TestFixture]
    public class SymbolRemoveServiceTests
    {
        private static ProcessedString GetResult(string originalString)
        {
            var symbolRemoveService = new SymbolRemoveService(new HttpClient() as IHttpClientFactory);
            var processedString = new ProcessedString(originalString);
            symbolRemoveService.AppendAdditionalInfo(new Parameters(processedString));
            return processedString;
        }

        [Test]
        public void LengthResultTest()
        {
            var processedString = GetResult("ab");

            Assert.AreEqual(processedString.ResultWithoutSymbol.Length, processedString.Result.Length - 1);
        }

        [Test]
        public void OneSymbolTest()
        {
            var processedString = GetResult("a");

            Assert.AreEqual(processedString.ResultWithoutSymbol, "");
        }
    }
}
