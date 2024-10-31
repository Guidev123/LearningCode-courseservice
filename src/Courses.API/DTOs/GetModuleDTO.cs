using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record GetModuleDTO(string Title, string Description, Guid CourseId, Course Course, IEnumerable<Lesson> Lessons)
    {
        public string Title { get; private set; } = Title;
        public string Description { get; private set; } = Description;
        public Guid CourseId { get; private set; } = CourseId;
        public Course Course { get; private set; } = Course;
        public IEnumerable<Lesson> Lessons { get; private set; } = Lessons;
        public static GetModuleDTO MapFromEntity(Module module) => new(module.Title, module.Description, module.CourseId, module.Course, []);
    }
}
