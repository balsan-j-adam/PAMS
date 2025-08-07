using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PAMS.Database;

var builder = WebApplication.CreateBuilder(args);

// Add environment variables (for Render deployment)
builder.Configuration.AddEnvironmentVariables();

// Use env var: ConnectionStrings__DefaultConnection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//  Add MySQL context with auto-detected version
builder.Services.AddDbContext<Mycontext>(options =>
	options.UseMySql(
		connectionString,
		ServerVersion.AutoDetect(connectionString),
		mySqlOptions => mySqlOptions.EnableRetryOnFailure() // optional
	)
);

// MVC, Session, Identity
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); // Already correct

// Build app
var app = builder.Build();

// Error Handling & HSTS
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

// Middleware Pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // If you're using Identity
app.UseAuthorization();
app.UseSession();         // After Routing

// Routes
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Admin}/{action=Login}/{id?}"
);

app.Run();
