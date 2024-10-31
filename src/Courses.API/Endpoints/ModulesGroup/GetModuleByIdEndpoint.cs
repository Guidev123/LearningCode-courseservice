using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.API.Endpoints.ModulesGroup
{
    public class GetModuleByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id:guid}", HandleAsync).RequireAuthorization("Premium").Produces<Response<GetModuleDTO?>>();

        public static async Task<IResult> HandleAsync(IModuleRepository moduleRepository,
                                                      Guid id)
        {
            var module = await moduleRepository.GetByIdAsync(id);
            if (module is null)
                return TypedResults.NotFound(new Response<GetModuleDTO>(null, 404, ResponseMessages.MODULE_NOT_FOUND.GetDescription()));

            var result = GetModuleDTO.MapFromEntity(module);
            return TypedResults.Ok(new Response<GetModuleDTO>(result, 200, ResponseMessages.VALID_OPERATION.GetDescription()));
        }
    }
}
