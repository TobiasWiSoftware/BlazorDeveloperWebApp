using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace BlazorServer.Components
{
    public partial class BackToTopBtnComponent
    {
        private ElementReference backToTopButton;
        private string ButtonClass => isVisible ? "active" : "";

        private bool isVisible;


        [JSInvokable]
        public void UpdateVisibility(double scrollPosition)
        {
            var shouldShow = scrollPosition > 100;
            if (isVisible != shouldShow)
            {
                isVisible = shouldShow;
                StateHasChanged();
            }
        }

        public async Task ScrollToTop()
        {
            await JSRuntime.InvokeVoidAsync("window.scrollTo", 0, 0);
        }

        public void Dispose()
        {
            JSRuntime.InvokeVoidAsync("Blazor.deregisterBackToTop");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.registerBackToTop", DotNetObjectReference.Create(this));

            }
        }


    }
}
