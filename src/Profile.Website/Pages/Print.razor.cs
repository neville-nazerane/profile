using Profile.Website.Models;
using Profile.Website.Services;

namespace Profile.Website.Pages
{
    public partial class Print(DataService dataService)
    {

        private readonly DataService _dataService = dataService;

        private readonly AllContents contents = new();

        protected override async Task OnInitializedAsync()
        {
            await _dataService.PopulateAllAsync(contents);
            await base.OnInitializedAsync();
        }

    }
}
