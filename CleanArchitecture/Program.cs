using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Manager;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Core.Repositories.Base;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<ApiContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(connectionString, serverVersion)
               // The following three options help with debugging, but should
               // be changed or removed for production.
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                {
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

                    c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description =
                            "Enter JWT in format: Bearer {token}",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-8wpu81nz.us.auth0.com/";
    options.Audience = "secondAPI";
});

//register service
builder.Services.AddTransient(typeof(IBaseManager<,>), typeof(BaseManager<,>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.MapGet("", k => k.Response.WriteAsJsonAsync("test"));
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();