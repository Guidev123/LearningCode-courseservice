using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class CourseRepository(CourseDbContext dbContext) : ICourseRepository
    {
        private readonly CourseDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Course?>> GetAllAsync(int pageNumber, int pageSize) =>
            await _dbContext.Courses.AsNoTracking().Include(x => x.Modules).ThenInclude(x => x.Lessons)
                                    .Where(x => !x.IsDeleted).OrderBy(x => x.CreatedAt).Skip((pageNumber - 1)* pageSize)
                                    .Take(pageSize).ToListAsync();
        public async Task<Course?> GetByIdAsync(Guid id) =>  await _dbContext.Courses.AsNoTracking().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        public async Task CreateAsync(Course course) => await _dbContext.AddAsync(course);
        public void UpdateAsync(Course course) => _dbContext.Courses.Update(course);
    }
}
