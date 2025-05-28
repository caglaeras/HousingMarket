using Housing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Housing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add EF Core DbContext FIRST
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity with default UI and EF Core store
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false; // Optional: skip email confirmation
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            // Add MVC + Razor Pages + Session
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new System.Globalization.CultureInfo("tr-TR") };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSession();

            var app = builder.Build();

            // Initialize the database (if needed)
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }

            // Configure middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseRequestLocalization();


            app.UseAuthentication(); // 🔹 REQUIRED for login
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages(); // 🔹 REQUIRED for Identity pages

            app.Run();
        }
    }
}
