using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record LessonDTO(string Title, string LinkVideo, Guid ModuleId)
    {
        public string Title { get; private set; } = Title;
        public string LinkVideo { get; private set; } = LinkVideo;
        public Guid ModuleId { get; private set; } = ModuleId;
        public Lesson MapToEntity(LessonDTO dto) => new(dto.Title, dto.LinkVideo, dto.ModuleId);
    }
}
