using PerformanceBiller.Contracts;
using PerformanceBiller.PlayCalculator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PerformanceBiller
{
    public class Statement
    {
        private List<IPlayCalculator> _calculateThemesService;

        public Statement(List<IPlayCalculator> calculateThemesService)
        {
            _calculateThemesService = calculateThemesService;
        }

        public string Create(InvoiceContract invoice, List<PlayContract> plays)
        {
            invoice.Amount = 0;
            invoice.Credits = 0;

            foreach (var performance in invoice.Performances)
            {
                var play = plays.First(x => x.Id == performance.PlayId);
                performance.Amount = 0;
                performance.Credits = 0;

                var calculator = _calculateThemesService.FirstOrDefault(x => x.Type == play.Type);

                if (calculator == null)
                    throw new NotImplementedException($"unknown type: { play.Type}");

                performance.Amount = calculator.CalculateAmount(performance.Audience);
                performance.Credits = calculator.CalculateCredits(performance.Audience);

                invoice.Amount += performance.Amount;
                invoice.Credits += performance.Credits;
            }

            return FormatResult(invoice, plays);
        }

        private string FormatResult(InvoiceContract invoice, List<PlayContract> plays)
        {
            var result = $"Statement for {invoice.Customer}\n";
            var cultureInfo = new CultureInfo("en-US");

            foreach (var performance in invoice.Performances)
            {
                var play = plays.First(x => x.Id == performance.PlayId);

                result += $" {play.Name}: {(performance.Amount / 100).ToString("C", cultureInfo)} ({performance.Audience} seats)\n";
            }

            result += $"Amount owed is {(invoice.Amount / 100).ToString("C", cultureInfo)}\n";
            result += $"You earned {invoice.Credits} credits\n";

            return result;
        }
    }
}