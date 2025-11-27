using Microsoft.JSInterop;
using Profile.Models;

namespace Profile.Website.Pages
{
    public partial class Index(IJSRuntime js)
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

        static readonly IEnumerable<SkillInfo> skills = [

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
        
        private readonly IJSRuntime _js = js;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await _js.InvokeVoidAsync("window.loaded");
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
