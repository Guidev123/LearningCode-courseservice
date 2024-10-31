using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class ModuleRepository(CourseDbContext dbContext) : IModuleRepository
    {
        private readonly CourseDbContext _dbContext = dbContext;
        public async Task CreateAsync(Module module) => await _dbContext.AddAsync(module);
        public async Task<Module?> GetByIdAsync(Guid id) => await _dbContext.Modules.AsNoTracking().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        public void UpdateAsync(Module module) => _dbContext.Modules.Update(module);
    }
}
