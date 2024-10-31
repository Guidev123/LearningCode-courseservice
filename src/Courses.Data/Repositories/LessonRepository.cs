using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class LessonRepository(CourseDbContext dbContext) : ILessonRepository
    {
        private readonly CourseDbContext _dbContext = dbContext;
        public async Task CreateAsync(Lesson lesson) => await _dbContext.AddAsync(lesson);
        public async Task<Lesson?> GetByIdAsync(Guid id) => await _dbContext.Lessons.AsNoTracking().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        public void UpdateAsync(Lesson lesson) => _dbContext.Lessons.Update(lesson);
    }
}
