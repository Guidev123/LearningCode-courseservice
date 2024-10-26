namespace Courses.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name, string description, bool justForPremium, List<Module> modules)
        {
            Name = name;
            Description = description;
            JustForPremium = justForPremium;
            Modules = modules;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool JustForPremium { get; private set; }
        public List<Module> Modules { get; private set; }
    }
}
