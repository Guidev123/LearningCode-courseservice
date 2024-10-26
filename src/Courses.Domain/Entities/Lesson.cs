namespace Courses.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(Guid moduleId, string name, string description, string linkVideo, Module module, List<Module> modules)
        {
            ModuleId = moduleId;
            Name = name;
            Description = description;
            LinkVideo = linkVideo;
            Module = module;
            Modules = modules;
        }

        public Guid ModuleId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string LinkVideo { get; private set; }
        public Module Module { get; private set; }
        public List<Module> Modules { get; private set; }
    }
}
