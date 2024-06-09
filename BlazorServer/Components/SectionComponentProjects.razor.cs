using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedLibrary.Dtos;
using System.Threading.Tasks;



namespace BlazorServer.Components
{
    public partial class SectionComponentProjects : ComponentBase
    {
        [Parameter]
        public SectionComponentProjectsDto? SectionComponentItem { get; set; }

        public MarkupString? ms { get => new MarkupString(SectionComponentItem.ImageDescription);}

        public SectionComponentProjects()
        {

        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.initializeSlider");
            }
        }

        private async Task GoToPrevImage(int i)
        {
            await JSRuntime.InvokeVoidAsync("Blazor.prevImage", i);
        }

        private async Task GoToNextImage(int i)
        {
            await JSRuntime.InvokeVoidAsync("Blazor.nextImage", i);
        }


    }
}
