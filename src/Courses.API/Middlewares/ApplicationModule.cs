using Courses.API.Services;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Data;
using Courses.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace Courses.API.Middlewares
{
    public static class ApplicationModule
    {
        public const int DEFAULT_PAGE = 1;
        public const int DEFAULT_SIZE = 25;

        public static void AddCustomMiddlewares(this WebApplicationBuilder builder)
        {
            builder.AddDbContextConfig();
            builder.AddDocumentationConfig();
            builder.AddSecurityConfig();
            builder.RegisterServices();
        }

        public static void AddDbContextConfig(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<CourseDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

        public static void AddDocumentationConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Lerning Code Enterprise API",
                    Contact = new OpenApiContact() { Name = "Guilherme Nascimento", Email = "guirafaelrn@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta forma: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();   

            builder.Services.AddTransient<IModuleRepository, ModuleRepository>();
            builder.Services.AddTransient<IModuleService, ModuleService>();

            builder.Services.AddTransient<ILessonRepository, LessonRepository>();
            builder.Services.AddTransient<ILessonService, LessonService>();
        }

        private static void AddSecurityConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
                };
            });

            builder.Services.AddAuthorizationBuilder()
                .AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        }
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void UseSecurity(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
