using BuberBreakfast.Models;
using BuberBreakfast.Models.Persistence;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    builder.Services.AddDbContext<BuberBreakfastDbContext>(options => options.UseSqlServer("Data Source=HP-PRO-OEGL\\SQLINTERVIEW;Initial Catalog=BuberBreakfast;User ID=sa;Password=Scrum20210001#;Encrypt=False"));
    //builder.Services.AddDbContext<BuberBreakfastDbContext>(options => options.UseSqlServer("Data Source=HP-PRO-OEGL\\SQLINTERVIEW; Initial Catalog = BuberBreakfast; Integrated Security = True;Encrypt=False"));
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}