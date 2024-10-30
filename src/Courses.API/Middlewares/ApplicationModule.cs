using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Services;
using Courses.Data;
using Courses.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.API.Middlewares
{
    public static class ApplicationModule
    {
        public const int DEFAULT_PAGE = 1;
        public const int DEFAULT_SIZE = 25;

        public static void AddCustomMiddlewares(this WebApplicationBuilder builder)
        {
            builder.AddDbContextConfig();
            builder.RegisterServices();
        }

        public static void AddDbContextConfig(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<CourseDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();   
        }
    }
}
