using Profile.Website.Models;

namespace Profile.Website.Sections
{
    public partial class Home
    {

        static readonly IEnumerable<ExperenceStat> experenceStats = [
                new()
                {
                    YearStarted = 2015,
                    Label = ".NET Development"
                },
                new()
                {
                    YearStarted = 2019,
                    Label = "Years US Experience"
                },
                new()
                {
                    YearStarted = 2017,
                    Label = "Years Worked"
                }
            ];

    }
}
