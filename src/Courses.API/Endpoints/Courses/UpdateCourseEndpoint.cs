
using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.Courses
{
    public class UpdateCourseEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id:guid}", HandleAsync).Produces<Response<CourseDTO>>();
    
        public static async Task<IResult> HandleAsync(ICourseService courseService,
                                                      IUnitOfWork unitOfWork,
                                                      CourseDTO courseDTO,
                                                      Guid id)
        {
            var result = await courseService.UpdateAsync(courseDTO.MapToEntity(courseDTO), id);

            return result.IsSuccess && await unitOfWork.Commit()
                                    ? TypedResults.NoContent()
                                    : TypedResults.BadRequest(result);
        }
    }
}
