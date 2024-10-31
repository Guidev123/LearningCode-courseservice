using Courses.Core.Entities;
using Courses.Core.Responses;

namespace Courses.Core.Interfaces.Services
{
    public interface ILessonService
    {
        Task<Response<Lesson?>> CreateAsync(Lesson lesson);
        Task<Response<Lesson?>> UpdateAsync(Lesson lesson, Guid id);
        Task<Response<Lesson?>> DeleteAsync(Guid id);
    }
}
