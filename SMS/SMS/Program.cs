using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS; //For DependancyContainerClass
using SMS.DBContext;
using SMS.IRepository;
using SMS.Repository;
using SMS.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("Development")));

#region==================== session =========================

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(200); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
    options.Cookie.IsEssential = true; // Make the session cookie essential
});
builder.Services.AddDistributedMemoryCache(); // Required for using sessions

#endregion

#region============= Cookie Based Authentication ============
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Set the login page URL
    options.LogoutPath = "/Auth/Logout"; // Set the logout page URL
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10); // 
    options.AccessDeniedPath = "/Auth/AccessDenied/"; // Set AccessDenied URL if Deny the access of an User after log in
});

builder.Services.AddAuthorization(options => //For Policy Based Authorization
{
    options.AddPolicy("SuperAdminPolicy", policy => policy.RequireRole("SuperAdmin"));
    options.AddPolicy("ApplicantPolicy", policy => policy.RequireRole("Applicant"));
    options.AddPolicy("StudentPolicy", policy => policy.RequireRole("Student"));
});

builder.Services.AddHttpContextAccessor();
#endregion


//builder.Services.AddTransient<IMasterService, MasterService>(); //Registering Service for Dependancy Injection
//As RegisterServices method is a Static method, so we don't need to create an instance of DependancyContainer class.
DependancyContainer.RegisterServices(builder.Services, builder, builder.Configuration); //Registering Service for Dependancy Injection


#region=================== PDF ===========================

var OsPlatform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
var context = new CustomAssemblyLoadContext();
if (OsPlatform.Contains("Windows"))
{
    /* ==================Windows server===================*/
    context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
}
else if (OsPlatform.Contains("linux"))
{
    /* ==================Linux server===================*/
    context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.so"));
}


builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

#endregion



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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
