
using Microsoft.EntityFrameworkCore;
using RescueTeam.DAL;
using RescueTeam.Services;
using RescueTeam.Services.Concrete;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RescueTeamDbContext>(options => options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RescueTeamDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<ITeamMemberWorkerService, TeamMemberWorkerService>();
//builder.Services.AddScoped<ITeamWorkerService, TeamWorkerService>(); TODO
//builder.Services.AddScoped<IMissionWorkerService, MissionWorkerService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RescueTeam.Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
