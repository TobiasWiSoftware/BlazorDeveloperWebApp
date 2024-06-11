using ASPWebAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Entities;

namespace ASPWebAPI.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            Console.WriteLine(app);
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using DataBaseContext dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
            string connectionString = dbContext.Database.GetDbConnection().ConnectionString;
            Console.WriteLine("!!!!" + connectionString + "!!!!!");

            // Check if the database exists
            var dbExists = dbContext.Database.CanConnect();

            // Database should be automatically created at this point


            // Apply any pending migrations
            dbContext.Database.Migrate();
            Console.WriteLine("Database successfully updated with Migrate.");

            SeedData(app).Wait();
        }

        public static async Task SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                string? defaultEmail = configuration["DefaultUser:Email"];
                string? defaultPassword = configuration["DefaultUser:Password"];


                // Prüfen, ob Benutzer bereits vorhanden sind
                if (!dbContext.Users.Any() && defaultEmail != null && defaultPassword != null)
                {
                    PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
                    UserEntity user = new UserEntity
                    {
                        Email = defaultEmail,
                        UserName = "DefaultAdmin"
                    };

                    var result = await userManager.CreateAsync(user, defaultPassword);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to seed user: " + result.Errors.First().Description);
                    }
                }
            }
        }
    }
}
