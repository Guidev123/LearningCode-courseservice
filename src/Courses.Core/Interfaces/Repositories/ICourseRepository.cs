using Courses.Core.Entities;

namespace Courses.Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course?>> GetAllAsync(int pageNumber, int pageSize);
        Task<Course?> GetByIdAsync(Guid id);
        Task CreateAsync(Course course);
        void UpdateAsync(Course course);
    }
}
