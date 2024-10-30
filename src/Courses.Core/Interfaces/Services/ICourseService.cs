using Courses.Core.Entities;
using Courses.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Interfaces.Services
{
    public interface ICourseService
    {
        Task<Response<Course?>> CreateAsync(Course course);
        Task<Response<Course?>> UpdateAsync(Course course, Guid id);
        Task<Response<Course?>> DeleteAsync(Guid id);
    }
}
