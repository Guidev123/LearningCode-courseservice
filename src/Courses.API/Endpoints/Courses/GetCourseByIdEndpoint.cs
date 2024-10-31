
using Courses.API.DTOs;
using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.API.Endpoints.Courses
{
    public class GetCourseByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id:guid}", HandleAsync).Produces<Response<GetCourseDTO?>>();

        public static async Task<IResult> HandleAsync(ICourseRepository courseRepository,
                                                      Guid id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null)
                return TypedResults.NotFound(new Response<GetCourseDTO>(null, 404, ResponseMessages.COURSE_NOT_FOUND.GetDescription()));

            var result = GetCourseDTO.MapFromEntity(course);
            return TypedResults.Ok(new Response<GetCourseDTO>(result, 200, ResponseMessages.VALID_OPERATION.GetDescription()));
        }

    }
}
