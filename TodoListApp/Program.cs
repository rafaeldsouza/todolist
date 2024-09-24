using TodoListApp.Business.Services;
using TodoListApp.Business.Services.Interfaces;
using TodoListApp.Data.Context;
using TodoListApp.Data.Repositories;
using TodoListApp.Data.Repositories.Interfaces;
using TodoListApp.Data.UnitOfWorks.Interfaces;
using TodoListApp.Data.UnitOfWorks;
using TodoListApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<ITodoItemUnitOfWork, TodoItemUnitOfWork>();
builder.Services.AddScoped<ITodoService, TodoService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<TodoContext>();
    context.Database.Migrate();
}

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
