using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Auth/Login");
        options.LogoutPath = new PathString("/Auth/Logout");
        options.Cookie = new CookieBuilder
        {
            Name = "ProjectWeb",
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            SecurePolicy = CookieSecurePolicy.SameAsRequest
        };
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(2);
        options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
        options.Events.OnRedirectToLogin = async context =>
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/Admin")))
            {
                context.Response.Redirect("/Admin/Auth/Login");
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }
        };
    });

builder.Services.AddDbContext<ProjectWebContext>();

builder.Services.AddScoped<ITempRepository, EfTempRepository>();
builder.Services.AddScoped<ITempService, TempManager>();

builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<IBookService, BookManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");
});

app.Run();
