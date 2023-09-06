using Microsoft.EntityFrameworkCore;
using BoilerPlate.Data;
using BoilerPlate.Models;

var allowSpecificOrigins = "allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// ajout du context de base de données
builder.Services.AddDbContext<BoilerPlateContext>(options =>

// TODO Choisis ton type de BDD
options.UseSqlServer(builder.Configuration.GetConnectionString("BoilerPlateContext") ?? throw new InvalidOperationException("Connection string 'BoilerPlateContext' not found.")));
//options.UseInMemoryDatabase("BoilerPlateContext"));

//Ajout des services de base
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        policyBuilder =>
        {
            policyBuilder
            .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
    SeedPeople.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
