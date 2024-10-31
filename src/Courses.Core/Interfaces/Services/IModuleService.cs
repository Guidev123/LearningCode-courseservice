using Courses.Core.Entities;
using Courses.Core.Responses;

namespace Courses.Core.Interfaces.Services
{
    public interface IModuleService
    {
        Task<Response<Module?>> CreateAsync(Module module);
        Task<Response<Module?>> UpdateAsync(Module module, Guid id);
        Task<Response<Module?>> DeleteAsync(Guid id);
    }
}
