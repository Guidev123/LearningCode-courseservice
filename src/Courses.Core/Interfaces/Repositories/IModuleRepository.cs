using Courses.Core.Entities;

namespace Courses.Core.Interfaces.Repositories
{
    public interface IModuleRepository
    {
        Task<Module?> GetByIdAsync(Guid id);
        Task CreateAsync(Module module);
        void UpdateAsync(Module module);
    }
}
