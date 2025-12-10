using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ReceptSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReceptSystem"));
});

builder.Services.AddScoped<LægehusRepository>();
builder.Services.AddScoped<BLL.LægehusBLL>();

builder.Services.AddScoped<ApotekRepository>();
builder.Services.AddScoped<BLL.ApotekBLL>();

builder.Services.AddScoped<ReceptRepository>();
builder.Services.AddScoped<BLL.ReceptBLL>();

builder.Services.AddScoped<OrdinationRepository>();
builder.Services.AddScoped<BLL.OrdinationBLL>();

builder.Services.AddScoped<ReceptUdleveringRepository>();
builder.Services.AddScoped<BLL.ReceptUdleveringBLL>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ReceptSystemContext>();
    ReceptSystemContextInitalizer.Seed(db);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();