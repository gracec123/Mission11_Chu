using Microsoft.EntityFrameworkCore;
using Mission11_Chu.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context with SQLite
builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookConnection"]);

});

// Register the EFBookRepo as a scoped service
builder.Services.AddScoped<IBookRepo, EFBookRepo>();

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

// Map a custom controller route for pagination
app.MapControllerRoute(
    name: "pagination", "Books/{pageNum}", new {Controller = "Home", action = "Index"} );

// Map default controller routes
app.MapDefaultControllerRoute();

app.Run();
