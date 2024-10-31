using Courses.Core.Entities;

namespace Courses.Core.Interfaces.Repositories
{
    public interface ILessonRepository
    {
        Task<Lesson?> GetByIdAsync(Guid id);
        Task CreateAsync(Lesson lesson);
        void UpdateAsync(Lesson lesson);
    }
}
