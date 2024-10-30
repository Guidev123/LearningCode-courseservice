namespace Courses.Core.Entities;

public class Lesson : Entity
{
    public Lesson(string title, string linkVideo, Guid moduleId, Module module)
    {
        Title = title;
        LinkVideo = linkVideo;
        ModuleId = moduleId;
        Module = module;
    }
    protected Lesson() { }
    public string Title { get; private set; } = string.Empty;
    public string LinkVideo { get; private set; } = string.Empty;
    public Guid ModuleId { get; private set; }
    public Module Module { get; private set; } = null!;
}
