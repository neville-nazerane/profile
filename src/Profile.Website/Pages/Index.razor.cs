using Profile.Website.Models;

namespace Profile.Website.Pages
{
    public partial class Index
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

        static readonly IEnumerable<SocialData> Socials =
            [
                new()
                {
                    Class = "github",
                    Icon = "bi-github",
                    Url = "https://github.com/neville-nazerane"
                },
                 new()
                {
                    Class = "linkedin",
                    Icon = "bi-linkedin",
                    Url = "https://www.linkedin.com/in/neville-nazerane"
                }
            ];

        public static readonly IEnumerable<SkillInfo> skills = [

            new()
            {
                Title = "C#",
                Description = "See sharp",
                Precentage = 90
            },
            new()
            {
                Title = "Maui",
                Description = "Android and iOS deployments",
                Precentage = 80
            },
            new()
            {
                Title = "Javascript",
                Description = "Javascript",
                Precentage = 70
            }
            
        ];

    }
}
