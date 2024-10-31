
using Courses.API.DTOs;
using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.ModulesEndpoint
{
    public class CreateModuleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync).RequireAuthorization("Admin").Produces<IResult>();
        public static async Task<IResult> HandleAsync(IModuleService moduleService,
                                                      IUnitOfWork unitOfWork,
                                                      ModuleDTO moduleDTO)
        {
            var result = await moduleService.CreateAsync(moduleDTO.MapToEntity(moduleDTO));
            return result.IsSuccess && await unitOfWork.CommitAsync()
                                    ? TypedResults.Created()
                                    : TypedResults.BadRequest(result);
        }
    }
}
