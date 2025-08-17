using Microsoft.EntityFrameworkCore;
using Mindware_Prototip.Context;
using Mindware_Prototip.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
builder.Services.AddDbContext<MindwareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MindwareDbConnection")));
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

    app.UseRouting();
using (var scope=app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MindwareContext>(); 
    context.Database.Migrate(); 

}
    app.UseAuthorization();
app.MapGet("/getall", (MindwareContext context) =>Results.Ok(context.DeviceDatas.ToList()));

app.MapGet("/create",(MindwareContext context, string Uuid)=>
{
    Tag tag = new Tag
    {
        Uuid = Uuid,
        RegisteredAt = DateTime.Now,
        IsDeleted = false ,
        Description = "This is a sample tag"   

    };
    context.Tags.Add(tag);  
    context.SaveChanges();
    Results.Ok("Tag created successfully");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
