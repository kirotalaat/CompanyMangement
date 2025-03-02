using BissnessLogicLayer.Interfaces;
using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using BissnessLogicLayer.Reprosatory;
using PresentationLayer.MappedProfiles;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyMangementDbcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            builder.Services.AddScoped<IEmployeeReprosatory, EmployeeReprosatory>();
            builder.Services.AddScoped<IDepartmentReprosatory, DepartmrntReprosatory>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.Run();
        }
    }
}
