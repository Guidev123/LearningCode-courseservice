
using Courses.API.DTOs;
using Courses.API.Middlewares;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Endpoints.Courses
{
    public class GetAllCoursesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync).Produces<Response<List<GetCourseDTO>>?>();
        public static async Task<IResult> HandleAsync(ICourseRepository courseRepository,
                                                      [FromQuery] int pageNumber = ApplicationModule.DEFAULT_PAGE,
                                                      [FromQuery] int pageSize = ApplicationModule.DEFAULT_SIZE)
        {
            var courses = await courseRepository.GetAllAsync(pageNumber, pageSize);
            if(courses is null)
                return TypedResults.NotFound(new Response<List<GetCourseDTO>>(null, 404, ResponseMessages.COURSE_NOT_FOUND.GetDescription()));

            var result = courses.Select(GetCourseDTO.MapFromEntity).ToList();
            return TypedResults.Ok(new Response<List<GetCourseDTO>>(result, 200, ResponseMessages.VALID_OPERATION.GetDescription()));
        }
    }
}
