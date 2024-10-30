using Courses.API.Endpoints.Courses;

namespace Courses.API.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");

            endpoints.MapGroup("api/courses")
                .WithTags("Courses")
                .MapEndpoint<GetAllCoursesEndpoint>()
                .MapEndpoint<GetCourseByIdEndpoint>()
                .MapEndpoint<DeleteCourseEndpoint>()
                .MapEndpoint<UpdateCourseEndpoint>()
                .MapEndpoint<CreateCourseEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
