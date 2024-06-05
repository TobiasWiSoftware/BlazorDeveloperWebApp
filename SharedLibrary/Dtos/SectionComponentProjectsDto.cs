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

        public List<String> SliderImagesBase64Data { get; set; }

        public String ImageTitle { get; set; }

        public String ImageDescription { get; set; }

        public List<String>? IconImagesBase64Data { get; set; }

        public SectionComponentProjectsDto(int id, string title, string description, List<string> sliderImagesBase64Data, string imageTitle, string imageDescription)
        {
            Title = title;
            Description = description;
            SliderImagesBase64Data = sliderImagesBase64Data;
            ImageTitle = imageTitle;
            ImageDescription = imageDescription;
        }

        public SectionComponentProjectsDto(int id, string title, string description, List<string> sliderImagesBase64Data, string imageTitle, string imageDescription, List<string> iconImagesBase64Data)
        {
            Title = title;
            Description = description;
            SliderImagesBase64Data = sliderImagesBase64Data;
            ImageTitle = imageTitle;
            ImageDescription = imageDescription;
            IconImagesBase64Data = iconImagesBase64Data;
        }
        
    }
}
