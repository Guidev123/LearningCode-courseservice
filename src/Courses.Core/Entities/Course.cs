namespace Courses.Core.Entities;

public class Course : Entity
{
    public Course(string name, string description, bool justForPremium, IEnumerable<Module> modules)
    {
        Name = name;
        Description = description;
        JustForPremium = justForPremium;
        Modules = modules;
    }
    protected Course() { }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool JustForPremium { get; private set; }
    public IEnumerable<Module> Modules { get; private set; } = [];
}
