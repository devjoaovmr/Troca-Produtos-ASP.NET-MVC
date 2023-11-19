using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpContextAccessor();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var conectionString = builder.Configuration.GetConnectionString("databaseUrl");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(conectionString).EnableSensitiveDataLogging(true));

            builder.Services.AddSession();

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}