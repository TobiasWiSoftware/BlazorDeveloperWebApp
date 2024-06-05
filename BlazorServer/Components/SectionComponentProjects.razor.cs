using Microsoft.AspNetCore.Components;
using SharedLibrary.Dtos;

namespace BlazorServer.Components
{
    public class SectionComponentBase : ComponentBase
    {
        [Parameter]
        public SectionComponentProjectsDto SectionComponentItem { get; set; }

        public MarkupString ms { get => new MarkupString(SectionComponentItem.ImageDescription);}


    }
}
