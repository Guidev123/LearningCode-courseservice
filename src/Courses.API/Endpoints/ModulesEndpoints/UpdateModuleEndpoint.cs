using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.ModulesEndpoints
{
    public class UpdateModuleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id:guid}", HandleAsync).RequireAuthorization("Admin").Produces<IResult>();

        public static async Task<IResult> HandleAsync(IModuleService moduleService,
                                                      IUnitOfWork unitOfWork,
                                                      ModuleDTO moduleDTO,
                                                      Guid id)
        {
            var result = await moduleService.UpdateAsync(moduleDTO.MapToEntity(moduleDTO), id);
            return result.IsSuccess && await unitOfWork.CommitAsync()
                                    ? TypedResults.NoContent()
                                    : TypedResults.BadRequest(result);
        }
    }
}
