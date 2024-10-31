using Courses.Core.Entities;
using Courses.Core.Entities.Validations;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.Core.Services
{
    public class ModuleService(IModuleRepository moduleRepository) : IModuleService
    {
        private readonly IModuleRepository _moduleRepository = moduleRepository;
        public async Task<Response<Module?>> CreateAsync(Module module)
        {
            var validationResult = new ModuleValidation().Validate(module);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Module?>(null, 400, ResponseMessages.VALID_OPERATION.GetDescription(), errorMessages);

            await _moduleRepository.CreateAsync(module);

            return new Response<Module?>(null, 201, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Module?>> DeleteAsync(Guid id)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            if (module is null)
                return new Response<Module?>(null, 404, ResponseMessages.MODULE_NOT_FOUND.GetDescription());

            if (module.Lessons.Any())
                return new Response<Module?>(null, 400, ResponseMessages.MODULE_CANNOT_BE_DELETED.GetDescription());

            module.SetEntityAsDeleted();
            _moduleRepository.UpdateAsync(module);

            return new Response<Module?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Module?>> UpdateAsync(Module module, Guid id)
        {
            var validationResult = new ModuleValidation().Validate(module);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Module?>(null, 400, ResponseMessages.VALID_OPERATION.GetDescription(), errorMessages);

            var oldModule = await _moduleRepository.GetByIdAsync(id);
            if (oldModule is null)
                return new Response<Module?>(null, 404, ResponseMessages.COURSE_NOT_FOUND.GetDescription());

            oldModule.UpdateModule(module.Title, module.Description);
            _moduleRepository.UpdateAsync(oldModule);

            return new Response<Module?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }
    }
}
