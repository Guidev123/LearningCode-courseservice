using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record GetAllCourseDTO(string Name, string Description, bool JustForPremium, IEnumerable<Module> Modules)
    {
        public string Name { get; private set; } = Name;
        public string Description { get; private set; } = Description;
        public bool JustForPremium { get; private set; } = JustForPremium;
        public IEnumerable<Module> Modules { get; private set; } = Modules;
        public static GetAllCourseDTO MapFromEntity(Course? course) => new(course!.Name, course.Description, course.JustForPremium, course.Modules);
    }
}
