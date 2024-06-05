using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Entities
{
    public class SectionComponentProjectsEntity
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public List<PictureEntity>? ImageSliderPictures { get; set; }

        public String ImageTitle { get; set; }

        public String ImageDescription { get; set; }

        public List<PictureEntity>? IconPictures { get; set; }

        public SectionComponentProjectsEntity(int id, string title, string description, string imageTitle, string imageDescription)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageTitle = imageTitle;
            ImageDescription = imageDescription;
        }

        public SectionComponentProjectsEntity(int id, string title, string description, List<PictureEntity> imageSliderPictures, string imageTitle, string imageDescription)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageSliderPictures = imageSliderPictures;
            ImageTitle = imageTitle;
            ImageDescription = imageDescription;
        }

        public SectionComponentProjectsEntity(int id, string title, string description, List<PictureEntity> imageSliderPictures, string imageTitle, string imageDescription, List<PictureEntity> iconPictures)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageSliderPictures = imageSliderPictures;
            ImageTitle = imageTitle;
            ImageDescription = imageDescription;
            IconPictures = iconPictures;
        }
    }
}
