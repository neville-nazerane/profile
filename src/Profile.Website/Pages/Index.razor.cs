using Microsoft.JSInterop;
using Profile.Models;
using Profile.Website.Services;

namespace Profile.Website.Pages
{
    public partial class Index(IJSRuntime js, DataService dataService)
    {

        static readonly ICollection<ExperenceStat> experenceStats = [];

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

        static readonly ICollection<SkillInfo> skills = [];
        
        private readonly IJSRuntime _js = js;
        private readonly DataService _dataService = dataService;

        protected override async Task OnInitializedAsync()
        {
            await foreach (var exp in _dataService.GetExperienceStatsAsync())
            {
                if (exp is not null)
                    experenceStats.Add(exp);
            }

            await foreach (var skill in _dataService.GetSkillInfoAsync())
            {
                if (skill is not null)
                    skills.Add(skill);
            }

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await _js.InvokeVoidAsync("window.loaded");
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
