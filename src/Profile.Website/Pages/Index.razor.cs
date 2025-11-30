using Microsoft.JSInterop;
using Profile.Models;
using Profile.Website.Models;
using Profile.Website.Services;

namespace Profile.Website.Pages
{
    public partial class Index(DataService dataService)
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

        readonly AllContents contents = new();

        readonly DataService _dataService = dataService;

        protected override async Task OnInitializedAsync()
        {

            await _dataService.PopulateAllAsync(contents);

            await base.OnInitializedAsync();
        }


    }
}
