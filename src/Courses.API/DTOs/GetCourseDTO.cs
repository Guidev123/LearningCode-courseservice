using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record GetCourseDTO(string Name, string Description, bool JustForPremium)
    {
        public string Name { get; private set; } = Name;
        public string Description { get; private set; } = Description;
        public bool JustForPremium { get; private set; } = JustForPremium;
        public static GetCourseDTO MapFromEntity(Course? course) => new(course!.Name, course.Description, course.JustForPremium);
    }
}
