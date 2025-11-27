namespace Profile.Models
{
    public class ExperenceStat
    {

        public required int YearStarted { get; set; }

        public required string Label { get; set; }

        public int YearsUntilNow => DateTime.Now.Year - YearStarted;

    }
}
