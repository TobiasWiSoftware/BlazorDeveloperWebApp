using Microsoft.AspNetCore.Components;
using SharedLibrary.Dtos;

namespace BlazorServer.Components
{
    public partial class SectionComponentIntroduction : ComponentBase
    {
        [Parameter]

        public SectionComponentIntroductionDto? SectionComponentItem { get; set; }




    }
}
