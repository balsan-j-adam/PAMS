using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PAMS.Database;



            var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<Mycontext>(options => 
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8, 0, 43))));
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

           

            app.UseAuthentication(); // Ensure Authentication is used
            app.UseAuthorization();  // Ensure Authorization is used
app.UseSession();


app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Login}/{id?}");

            //app.MapGet("/", context =>
            //{
            //    context.Response.Redirect("/Identity/Account/Login");
            //    return Task.CompletedTask;
            //});



            app.Run();
        

        // ==============================  Authentication  ==============================  


        // ==============================  Authentication  ==============================  

        



    

