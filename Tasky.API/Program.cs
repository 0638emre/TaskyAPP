using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;
using Tasky.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

var emreAllowSomeCors = "emre.coskun";

builder.Services.AddCors(options =>
{
    options.AddPolicy(emreAllowSomeCors,
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:3000") // İzin vermek istediğiniz istemci adresini ekleyin
                // .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                // .AllowAnyOrigin()
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                ;
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TaskyDB")));


//IOC Container
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IKonuService, KonuService>();
builder.Services.AddScoped<IKullaniciKonuService, KullaniciKonuService>();
builder.Services.AddScoped<IYetkiService, YetkiService>();
builder.Services.AddScoped<IKullaniciYetkiService, KullaniciYetkiService>();
builder.Services.AddScoped<ILugatService, LugatService>();
builder.Services.AddScoped<IIletisimService, IletisimService>();
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

app.UseCors(emreAllowSomeCors);

app.Run();