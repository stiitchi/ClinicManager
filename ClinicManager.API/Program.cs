using ClinicManager.API;
using ClinicManager.Application;
using ClinicManager.Application.Helpers;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Infrastructure;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services.AddInfrastructure(config);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicManager.API", Version = "v1" });
});
var jwtSection = config.GetSection("AppSettings");
builder.Services.Configure<ClinicManager.Application.AppSettings>(jwtSection);

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();   
//}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicManager.API v1"));

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();


using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>()
               .CreateScope())
{
    var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    try
    {
        AddAdminUser(db);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}


void AddAdminUser(ApplicationDbContext db)
{
    var adminExist = db.Users.FirstOrDefault(u => u.FirstName.ToLower() == "system");
    if (adminExist == null)
    {
        var adminUser = new UserEntity("System", "Admin", "admin@domain.com");
        byte[] passwordHash;
        byte[] passwordSalt;
        adminUser.SetEmail("admin@domain.com");
        adminUser.SetActivationToken("token");
        PasswordHelper.CreatePasswordHash("tempP@ss123", out passwordHash, out passwordSalt);
        adminUser.SetPassword(passwordHash, passwordSalt);
        adminUser.SetPasswordReset("token", DateTime.Now);
        db.Users.Add(adminUser);
        db.SaveChanges();
    }
}


