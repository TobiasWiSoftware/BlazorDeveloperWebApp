using ASPWebAPI.Data;
using ASPWebAPI.Extensions;
using ASPWebAPI.Repositories.Implementation;
using ASPWebAPI.Repositories.Interface;
using ASPWebAPI.Services.Implementation;
using ASPWebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Configurations;
using SharedLibrary.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TokenServiceOptions>(builder.Configuration.GetSection("TokenServiceOptions"));

builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISectionComponentProjectsService, SectionComponentProjectsService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString != null)
{
    builder.Services.AddDbContext<DataBaseContext>(options =>
    {
        options.UseLazyLoadingProxies().UseMySQL(connectionString);
    });
}



builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false; // Set to false to exclude special characters
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
}
        ).AddEntityFrameworkStores<DataBaseContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication();





var app = builder.Build();

app.ApplyMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
