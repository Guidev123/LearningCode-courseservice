using Courses.API.DTOs;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.API.Endpoints.LessonsEndpoints
{
    public class GetLessonByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id:guid}", HandleAsync).RequireAuthorization("Premium").Produces<Response<GetLessonDTO?>>();

        public static async Task<IResult> HandleAsync(ILessonRepository lessonRepository,
                                                      Guid id)
        {
            var lesson = await lessonRepository.GetByIdAsync(id);
            if (lesson is null)
                return TypedResults.NotFound(new Response<GetLessonDTO>(null, 404, ResponseMessages.LESSON_NOT_FOUND.GetDescription()));

            var result = GetLessonDTO.MapFromEntity(lesson);
            return TypedResults.Ok(new Response<GetLessonDTO>(result, 200, ResponseMessages.VALID_OPERATION.GetDescription()));
        }
    }
}
