using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Courses.Infrastructure
{
    public class CoursesDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;
        public CoursesDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            string connectionString = _configuration.GetConnectionString("DbConnection") ?? string.Empty;

            MongoUrl mongoUrl = MongoUrl.Create(connectionString);
            MongoClient mongoClient = new(mongoUrl);

            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoDatabase? Database => _database;
    }
}
