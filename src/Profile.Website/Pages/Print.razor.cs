using Microsoft.JSInterop;
using Profile.Website.Models;
using Profile.Website.Services;
using System.Runtime.CompilerServices;

namespace Profile.Website.Pages
{
    public partial class Print(DataService dataService, IJSRuntime js)
    {

        private readonly DataService _dataService = dataService;
        private readonly IJSRuntime _js = js;

        private readonly AllContents contents = new();

        protected override async Task OnInitializedAsync()
        {
            await _dataService.PopulateAllAsync(contents);
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender)
                await _js.InvokeVoidAsync("window.print");
        }

    }
}
