using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ST10037089__prog3ap2_Final_.Data;


public class Program
{
    public static async Task Main(string[] args)
    {
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
           .AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            // Seeding roles 
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Creating an array of roles
            var roles = new[] { "Farmer", "Employee", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            // Seeding users
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Admin user
            string adminEmail = "admin@admin.com";
            string adminPassword = "Test123#";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Employee");
            }

            // Farmer users
            var farmers = new[]
            {
                new { Email = "farmer1@farm.com", Password = "Farmer123#" },
                new { Email = "farmer2@farm.com", Password = "Farmer123#" },
                new { Email = "farmer3@farm.com", Password = "Farmer123#" },
                new { Email = "farmer4@farm.com", Password = "Farmer123#" },
                  new { Email = "farmer5@farm.com", Password = "Farmer123#" },
                    new { Email = "farmer6@farm.com", Password = "Farmer123#" },
                      new { Email = "farmer7@farm.com", Password = "Farmer123#" },
                        new { Email = "farmer8@farm.com", Password = "Farmer123#" },
                          new { Email = "farmer9@farm.com", Password = "Farmer123#" },
                            new { Email = "farmer10@farm.com", Password = "Farmer123#" }
              
            };

            foreach (var farmer in farmers)
            {
                if (await userManager.FindByEmailAsync(farmer.Email) == null)
                {
                    var farmerUser = new IdentityUser { UserName = farmer.Email, Email = farmer.Email };
                    await userManager.CreateAsync(farmerUser, farmer.Password);
                    await userManager.AddToRoleAsync(farmerUser, "Farmer");
                }
            }
        }

        app.Run();
    }
}
