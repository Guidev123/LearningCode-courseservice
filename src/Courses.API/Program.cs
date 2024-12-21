using Courses.API.Configurations;
using Courses.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddConfigurations();
var app = builder.Build();

app.ConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();