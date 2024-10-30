using Courses.Core.Entities;

namespace Courses.Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course?>> GetAll(int pageNumber, int pageSize);
        Task<Course?> GetById(Guid id);
        Task CreateAsync(Course course);
        void UpdateAsync(Course course);
    }
}
