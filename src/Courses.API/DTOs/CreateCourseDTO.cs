using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record CreateCourseDTO(string Name, string Description, bool JustForPremium)
    {
        public string Name { get; private set; } = Name;
        public string Description { get; private set; } = Description;
        public bool JustForPremium { get; private set; } = JustForPremium;
        public Course MapToEntity(CreateCourseDTO dto) => new(dto.Name, dto.Description, dto.JustForPremium);
    }
}
