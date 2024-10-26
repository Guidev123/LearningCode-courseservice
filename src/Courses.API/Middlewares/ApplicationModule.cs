using Courses.Infrastructure;
using MongoDB.Driver;

namespace Courses.API.Middlewares
{
    public static class ApplicationModule
    {
        public static void AddMongoMiddleware(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<CoursesDbContext>();

            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DbConnection");
                return new MongoClient(connectionString);
            });

            builder.Services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(builder.Configuration.GetSection("ConnectionStrings")["Database"]);
            });
        }
    }
}
