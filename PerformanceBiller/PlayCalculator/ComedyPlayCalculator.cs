using System;

namespace PerformanceBiller.PlayCalculator
{
    public class ComedyService : IPlayCalculator
    {
        public PlayTypeEnum Type { get => PlayTypeEnum.Comedy; }

        public int CalculateAmount(int audience)
        {
            var thisAmount = 30000;
            if (audience > 20)
            {
                thisAmount += 10000 + 500 * (audience - 20);
            }
            thisAmount += 300 * audience;

            return thisAmount;
        }

        public int CalculateCredits(int audience)
        {
            var extra = audience / 5;
            extra += Math.Max(audience - 30, 0);

            return extra;            
        }
    }
}