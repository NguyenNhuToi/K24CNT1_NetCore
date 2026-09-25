using Microsoft.EntityFrameworkCore;
using TvcLesson10EFDbFirst.Models;

namespace TvcLesson10EFDbFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Lấy chuỗi kết nối từ appsettings.json
            var tvcConnection = builder.Configuration.GetConnectionString("TvcK24CNT1Lesson10");
            builder.Services.AddDbContext<TvcK24cnt1lesson10EfdbContext>(x=>x.UseSqlServer(tvcConnection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
