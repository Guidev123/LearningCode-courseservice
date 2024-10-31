namespace Courses.Core.Entities;

public class Lesson : Entity
{
    public Lesson(string title, string linkVideo, Guid moduleId)
    {
        Title = title;
        LinkVideo = linkVideo;
        ModuleId = moduleId;
    }
    protected Lesson() { }
    public string Title { get; private set; } = string.Empty;
    public string LinkVideo { get; private set; } = string.Empty;
    public Guid ModuleId { get; private set; }
    public Module Module { get; private set; } = null!;

    public void UpdateLesson(string title, string linkvideo)
    {
        Title = title;
        LinkVideo = linkvideo;
    }
}
