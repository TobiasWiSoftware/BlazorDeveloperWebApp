using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class SectionComponentIconDto
    {
        public String IconsBase64Data { get; set; }

        public String LinkData { get; set; }

        public SectionComponentIconDto(string iconsBase64Data, string linkData)
        {
            IconsBase64Data = iconsBase64Data;
            LinkData = linkData;
        }
    }
}
