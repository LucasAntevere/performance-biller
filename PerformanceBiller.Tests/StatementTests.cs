using Newtonsoft.Json;
using PerformanceBiller.Contracts;
using PerformanceBiller.PlayCalculator;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace PerformanceBiller.Tests
{
    public class StatementTests
    {
        [Fact]
        public void Statement_can_run()
        {
            var expectedOutput = "Statement for BigCo\n" +
                " Hamlet: $650.00 (55 seats)\n" +
                " As You Like It: $580.00 (35 seats)\n" +
                " Othello: $500.00 (40 seats)\n" +
                "Amount owed is $1,730.00\n" +
                "You earned 47 credits\n";

            var comedyCalculator = new ComedyService();
            var tragedyCalculator = new TragedyPlayCalculator();

            var calculators = new List<IPlayCalculator>()
            {
                comedyCalculator,
                tragedyCalculator
            };

            var statement = new Statement(calculators);

            using (var invoicesFile = File.OpenText("..\\..\\..\\invoices.json"))
            using (var playsFile = File.OpenText("..\\..\\..\\plays.json"))
            { 
                var invoiceJson = invoicesFile.ReadToEnd(); ;
                var invoices = JsonConvert.DeserializeObject<List<InvoiceContract>>(invoiceJson);

                var playsJson = playsFile.ReadToEnd();
                var plays = JsonConvert.DeserializeObject<List<PlayContract>>(playsJson);

                var actualResult = statement.Create(invoices.First(), plays);
                
                Assert.Equal(expectedOutput, actualResult);
            }
        }
    }
}
