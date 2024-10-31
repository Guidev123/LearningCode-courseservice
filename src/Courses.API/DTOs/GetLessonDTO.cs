using Courses.Core.Entities;

namespace Courses.API.DTOs
{
    public record GetLessonDTO(string Title, string LinkVideo)
    {
        public string Title { get; private set; } = Title;
        public string LinkVideo { get; private set; } = LinkVideo;
        public static GetLessonDTO MapFromEntity(Lesson lesson) => new(lesson.Title, lesson.LinkVideo);
    }
}
