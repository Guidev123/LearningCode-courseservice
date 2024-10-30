using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class CourseRepository(CourseDbContext dbContext) : ICourseRepository
    {
        private readonly CourseDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Course?>> GetAll(int pageNumber, int pageSize)
        {
            var query = _dbContext.Courses.AsNoTracking().Include(x => x.Modules).ThenInclude(x => x.Lessons).OrderBy(x => x.CreatedAt);
            return await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Course?> GetById(Guid id) =>  await _dbContext.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task CreateAsync(Course course) => await _dbContext.AddAsync(course);
        public void UpdateAsync(Course course) => _dbContext.Courses.Update(course);
    }
}
