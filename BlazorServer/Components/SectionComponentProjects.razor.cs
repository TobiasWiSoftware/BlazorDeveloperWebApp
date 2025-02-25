using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedLibrary.Dtos;



namespace BlazorServer.Components
{
    public partial class SectionComponentProjects : ComponentBase
    {
        [Parameter]
        public SectionComponentProjectsDto? SectionComponentItem { get; set; }

        public string selectedSlide = "0";

        public SectionComponentProjects()
        {

        }

    }
}
