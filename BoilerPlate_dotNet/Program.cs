using BoilerPlate_dotNet.Data;
using BoilerPlate_dotNet.Repository.Interface;
using BoilerPlate_dotNet.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var allowSpecificOrigins = "allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
//// TODO Choisis ton type de BDD
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("BoilerPlateContext")
    ));

builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IPersonneRepository, PersonneRepository>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

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

// TODO pour le seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData.Initialize(services);
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
