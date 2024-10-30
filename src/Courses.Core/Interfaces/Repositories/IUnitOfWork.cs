using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task<bool> Rollback();
    }
}
