namespace PerformanceBiller.PlayCalculator
{
    public interface IPlayCalculator
    {
        PlayTypeEnum Type { get; }

        int CalculateAmount(int audience);
        int CalculateCredits(int audience);
    }
}