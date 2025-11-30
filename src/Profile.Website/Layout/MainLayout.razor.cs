using Microsoft.JSInterop;

namespace Profile.Website.Layout
{
    public partial class MainLayout(IJSRuntime js)
    {
        readonly IJSRuntime _js = js;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await _js.InvokeVoidAsync("window.loaded");
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
