
using Courses.API.DTOs;
using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.Courses
{
    public class CreateCourseEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync).Produces<Response<Course?>>();

        public static async Task<IResult> HandleAsync(ICourseService courseService,
                                                      IUnitOfWork unitOfWork,
                                                      CreateCourseDTO courseDTO)
        {
            var result = await courseService.CreateAsync(courseDTO.MapToEntity(courseDTO));

            return result.IsSuccess && await unitOfWork.Commit()
                                    ? TypedResults.Created()
                                    : TypedResults.BadRequest(result);
        }
    }
}
