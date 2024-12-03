using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;

namespace Courses.API.Endpoints.CoursesEndpoints
{
    public class CreateCourseEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync).RequireAuthorization("Admin").Produces<IResult>();

        public static async Task<IResult> HandleAsync(ICourseService courseService,
                                                      IUnitOfWork unitOfWork,
                                                      CourseDTO courseDTO)
        {
            var result = await courseService.CreateAsync(courseDTO.MapToEntity(courseDTO));
            return result.IsSuccess && await unitOfWork.CommitAsync()
                                    ? TypedResults.Created()
                                    : TypedResults.BadRequest(result);
        }
    }
}
