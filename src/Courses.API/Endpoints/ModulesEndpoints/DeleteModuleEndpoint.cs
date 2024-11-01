using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.ModulesEndpoints
{
    public class DeleteModuleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id:guid}", HandleAsync).RequireAuthorization("Admin").Produces<IResult>();

        public static async Task<IResult> HandleAsync(IModuleService moduleService,
                                                      IUnitOfWork unitOfWork,
                                                      Guid id)
        {
            var result = await moduleService.DeleteAsync(id);
            return result.IsSuccess && await unitOfWork.CommitAsync()
                                    ? TypedResults.NoContent()
                                    : TypedResults.BadRequest();
        }
    }
}
