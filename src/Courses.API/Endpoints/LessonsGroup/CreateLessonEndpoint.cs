using Courses.API.DTOs;
using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.LessonsGroup
{
    public class CreateLessonEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync).RequireAuthorization("Admin").Produces<IResult>();
        public static async Task<IResult> HandleAsync(ILessonService lessonService,
                                                      IUnitOfWork unitOfWork,
                                                      LessonDTO lessonDTO)
        {
            var result = await lessonService.CreateAsync(lessonDTO.MapToEntity(lessonDTO));
            return result.IsSuccess && await unitOfWork.CommitAsync()
                                    ? TypedResults.Created()
                                    : TypedResults.BadRequest(result);
        }
    }
}
