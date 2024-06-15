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


        public void NextImage(SectionComponentProjectDto item)
        {
            if (item != null && item.ImageOnDisplayIndex + 1 < item.SliderImagesBase64Data.Count)
            {
                item.ImageOnDisplayIndex++;
            }
        }

        public void PrevImage(SectionComponentProjectDto item)
        {
            if (item != null && item.ImageOnDisplayIndex  > 0)
            {
                item.ImageOnDisplayIndex--;
            }

        }


    }
}
