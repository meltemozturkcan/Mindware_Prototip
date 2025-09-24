using Microsoft.EntityFrameworkCore;
using Mindware_Prototip.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MindwareContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MindwareDbConnection"),
        sql => {
            sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            sql.CommandTimeout(120);
        }));

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllers();

// Dev’de migrate, Prod’da deðil
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MindwareContext>();
    await db.Database.MigrateAsync();
}

app.Run();