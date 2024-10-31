using Courses.API.Endpoints.CoursesEndpoint;
using Courses.API.Endpoints.LessonsGroup;
using Courses.API.Endpoints.ModulesEndpoint;
using Courses.API.Endpoints.ModulesGroup;

namespace Courses.API.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");

            endpoints.MapGroup("api/v1/courses")
                .WithTags("Courses")
                .RequireAuthorization()
                .MapEndpoint<GetAllCoursesEndpoint>()
                .MapEndpoint<GetCourseByIdEndpoint>()
                .MapEndpoint<DeleteCourseEndpoint>()
                .MapEndpoint<UpdateCourseEndpoint>()
                .MapEndpoint<CreateCourseEndpoint>();

            endpoints.MapGroup("api/v1/modules")
                .WithTags("Modules")
                .RequireAuthorization()
                .MapEndpoint<GetModuleByIdEndpoint>()
                .MapEndpoint<CreateModuleEndpoint>()
                .MapEndpoint<UpdateModuleEndpoint>()
                .MapEndpoint<DeleteModuleEndpoint>();

            endpoints.MapGroup("api/v1/lessons")
                .WithTags("Lessons")
                .RequireAuthorization()
                .MapEndpoint<GetLessonByIdEndpoint>()
                .MapEndpoint<CreateLessonEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
