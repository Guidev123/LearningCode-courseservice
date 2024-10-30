using Courses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class UnitOfWork(CourseDbContext context) : IUnitOfWork
    {
        private readonly CourseDbContext _context = context;
        public async Task<bool> Commit()
        {
            var ret = await _context.SaveChangesAsync();
            if (ret > 0)
                return true;

            return false;
        }

        public async Task<bool> Rollback() => await Task.FromResult(true);
    }
}
