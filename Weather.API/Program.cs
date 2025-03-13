using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using Weather.API.Data;
using Weather.API.Mappings;
using Weather.API.Middlewares;
using Weather.API.Repositories;
using Weather.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/Weather_Log.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo { Title = "Wether API", Version = "v1" });
options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
{
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = JwtBearerDefaults.AuthenticationScheme
});

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<WeatherDataDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDBConnectionString")));

builder.Services.AddDbContext<WeatherAuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherAuthConnectionString")));
// Register OpenWeather API Service
builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});
builder.Services.AddScoped<IOpenWeatherService, OpenWeatherService>();
//builder.Services.AddTransient<IOpenWeatherService, OpenWeatherService>();
builder.Services.AddScoped<IWeatherDataRepository, SQLWeatherDataRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("WeatherProvider")
    .AddEntityFrameworkStores<WeatherAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters
    {
    AuthenticationType = "Jwt",
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    //ValidAudience = builder.Configuration["Jwt: Audience"],        
    ValidAudiences = new[] { builder.Configuration["Jwt:Audience"] },
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

#pragma warning restore CS8604 // Possible null reference argument.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
