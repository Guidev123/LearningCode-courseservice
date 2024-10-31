using Courses.API.Endpoints;
using Courses.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddCustomMiddlewares();
var app = builder.Build();

app.ConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();