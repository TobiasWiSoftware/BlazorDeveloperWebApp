using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class SectionComponentProjectDto
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public List<String> SliderImagesBase64Data { get; set; }

        public int ImageOnDisplayIndex { get; set; }



        public SectionComponentProjectDto(string title, string description, List<string> sliderImagesBase64Data)
        {
            Title = title;
            Description = description;
            SliderImagesBase64Data = sliderImagesBase64Data;
            ImageOnDisplayIndex = 0;
        }


    }
}
