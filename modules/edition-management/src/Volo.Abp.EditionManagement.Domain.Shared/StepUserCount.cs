namespace Volo.Abp.EditionManagement
{
    public class StepUserCount
    {
        public int ReachCount { get; set; }

        public int HandselCount { get; set; }

        public StepUserCount(int reachCount, int handselCount)
        {
            ReachCount = reachCount;
            HandselCount = handselCount;
        }
    }
}
