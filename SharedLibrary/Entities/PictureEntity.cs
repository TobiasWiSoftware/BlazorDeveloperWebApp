using SharedLibrary.Entities;

public class PictureEntity
{

    public int Id { get; set; }
    public int RunningId { get; set; }
    public int? SectionComponentProjectsEntityId { get; set; }
    public int? SectionComponentProjectsEntityForSliderId { get; set; }
    public SectionComponentProjectsEntity? SectionComponentProjectsEntityForSlider { get; set; }
    public SectionComponentProjectsEntity? SectionComponentProjectsEntityForIcons { get; set; }
    public string Title { get; set; }
    public string Base64Data { get; set; }

    // Constructor with only mapped properties (if necessary)
    public PictureEntity(int id, string title, string base64Data)
    {
        Id = id;
        Title = title;
        Base64Data = base64Data;
    }
}
