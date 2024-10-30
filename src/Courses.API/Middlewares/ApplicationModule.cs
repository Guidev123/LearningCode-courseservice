using Courses.Data;
using Microsoft.EntityFrameworkCore;

namespace Courses.API.Middlewares
{
    public static class ApplicationModule
    {
        public static void AddCustomMiddlewares(this WebApplicationBuilder builder)
        {
            builder.AddDbContextConfig();
        }

        public static void AddDbContextConfig(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<CourseDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));
    }
}
