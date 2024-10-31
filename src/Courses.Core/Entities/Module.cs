namespace Courses.Core.Entities;

public class Module : Entity
{
    public Module(string title, string description, Guid courseId)
    {
        Title = title;
        Description = description;
        CourseId = courseId;
        Lessons = [];
    }

    protected Module() { }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; } = null!;
    public List<Lesson> Lessons { get; private set; } = [];
    public void UpdateModule(string title, string desciption)
    {
        Title = title;
        Description = desciption;
    }

}
