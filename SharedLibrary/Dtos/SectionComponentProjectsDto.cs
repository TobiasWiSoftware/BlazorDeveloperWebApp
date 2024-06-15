using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class SectionComponentProjectsDto
    {
        public String Title { get; set; }    

        public String Description { get; set; } 

        public List<SectionComponentProjectDto> SectionComponentProjects { get; set; }

        public List<SectionComponentIconDto>? Icons { get; set; }

        public string? SectionComponentProjectsHtmlId { get; set; }

        public SectionComponentProjectsDto(String title, string description, List<SectionComponentProjectDto> sectionComponentProjects, List<SectionComponentIconDto> icons)
        {
            Title = title;
            Description = description;
            SectionComponentProjects = sectionComponentProjects;
            Icons = icons;
        }

        public SectionComponentProjectsDto(String title, string description, List<SectionComponentProjectDto> sectionComponentProjects, List<SectionComponentIconDto> icons, string sectionComponentProjectsHtmlId)
        {
            Title = title;
            Description = description;
            SectionComponentProjects = sectionComponentProjects;
            Icons = icons;
            SectionComponentProjectsHtmlId = sectionComponentProjectsHtmlId;
        }
        
    }
}
