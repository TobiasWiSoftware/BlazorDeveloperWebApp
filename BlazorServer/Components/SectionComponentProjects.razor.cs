using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedLibrary.Dtos;



namespace BlazorServer.Components
{
    public partial class SectionComponentProjects : ComponentBase
    {
        [Parameter]
        public SectionComponentProjectsDto? SectionComponentItem { get; set; }

        public SectionComponentProjects()
        {

        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.init_slider");
            }
        }


    }
}
