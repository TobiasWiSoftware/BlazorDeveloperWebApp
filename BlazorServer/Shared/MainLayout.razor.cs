using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;


namespace BlazorServer.Shared
{
    public partial class MainLayout
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.aos_init", DotNetObjectReference.Create(this));

            }
        }
    }
}
