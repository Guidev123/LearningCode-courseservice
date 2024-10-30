
using Courses.API.DTOs;
using Courses.API.Middlewares;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Endpoints.Courses
{
    public class GetAllCoursesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync).Produces<Response<List<GetAllCourseDTO>>?>();
        public static async Task<IResult> HandleAsync(ICourseRepository courseRepository,
                                                      [FromQuery] int pageNumber = ApplicationModule.DEFAULT_PAGE,
                                                      [FromQuery] int pageSize = ApplicationModule.DEFAULT_SIZE)
        {
            var courses = await courseRepository.GetAll(pageNumber, pageSize);
            if(courses is null)
                return TypedResults.NotFound();

            var result = courses.Select(GetAllCourseDTO.MapFromEntity).ToList();
            return TypedResults.Ok(result);
        }
    }
}
