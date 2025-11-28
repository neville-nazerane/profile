using Microsoft.JSInterop;
using Profile.Models;
using Profile.Website.Services;

namespace Profile.Website.Pages
{
    public partial class Index(IJSRuntime js, DataService dataService)
    {


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

        static readonly ICollection<ExperenceStat> experenceStats = [];

        static readonly ICollection<PersonalInfo> personalInfo = [];

        static readonly ICollection<SkillInfo> skills = [];

        static readonly ICollection<ResumeItem> workItems = [];

        static readonly ICollection<ResumeItem> educationItems = [];

        private readonly IJSRuntime _js = js;
        private readonly DataService _dataService = dataService;

        protected override async Task OnInitializedAsync()
        {

            await foreach (var info in _dataService.GetPersonalInfoAsync())
            {
                if (info is not null)
                    personalInfo.Add(info);
            }


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

            await foreach (var work in _dataService.GetWorkResumeItemsAsync())
            {
                if (work is not null)
                    workItems.Add(work);
            }

            await foreach (var education in _dataService.GetEducationResumeItemsAsync())
            {
                if (education is not null)
                    educationItems.Add(education);
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
