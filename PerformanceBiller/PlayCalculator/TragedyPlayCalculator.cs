using System;

namespace PerformanceBiller.PlayCalculator
{
    public class TragedyPlayCalculator : IPlayCalculator
    {
        public PlayTypeEnum Type { get => PlayTypeEnum.Tragedy; }

        public int CalculateAmount(int audience)
        {
            var thisAmount = 40000;
            if (audience > 30)
            {
                thisAmount += 1000 * (audience - 30);
            }

            return thisAmount;
        }

        public int CalculateCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
