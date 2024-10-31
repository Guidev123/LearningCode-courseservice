using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record ModuleDTO(string Title, string Description, Guid CourseId)
    {
        public string Title { get; private set; } = Title;
        public string Description { get; private set; } = Description;
        public Guid CourseId { get; private set; } = CourseId;
        public Module MapToEntity(ModuleDTO dto) => new(dto.Title, dto.Description, dto.CourseId);

    }
}
