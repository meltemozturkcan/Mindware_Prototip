using Microsoft.EntityFrameworkCore;
using Mindware_Prototip.Context;
using Mindware_Prototip.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MindwareContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MindwareDbConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            sqlOptions.CommandTimeout(120); // 2 dakika timeout
        }));

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

// --- Güvenli migration bloðu ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<MindwareContext>();
        logger.LogInformation("Starting database migration...");
        context.Database.Migrate();
        logger.LogInformation("Database migration completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        // throw; // Ýstersen burada tekrar fýrlatabilirsin, ama Azure’da 500.30’a sebep olur.
    }
}
// --------------------------------

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllers();

// Minimal API örnekleri
app.MapGet("/getall", (MindwareContext context) => Results.Ok(context.DeviceDatas.ToList()));

app.MapGet("/create", (MindwareContext context, string Uuid) =>
{
    Tag tag = new Tag
    {
        Uuid = Uuid,
        RegisteredAt = DateTime.Now,
        IsDeleted = false,
        Description = "This is a sample tag"
    };

    context.Tags.Add(tag);
    context.SaveChanges();

    return Results.Ok("Tag created successfully");
});

app.Run();