using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;
using Tasky.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TaskyDB")));

builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IKonuService, KonuService>();

//best practice değil!!

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();