using hunter_api.Extensions;
using hunter_api.Interfaces;
using hunter_api.Services;
using hunter_domain.Domain;
using hunter_domain.Interfaces;
using hunter_repository.Interface;
using hunter_repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Services

builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddScoped<IRegisterPlatesDomain, RegisterPlatesDomain>();
builder.Services.AddScoped<IRegisterPlatesService, RegisterPlatesService>();
builder.Services.AddScoped<IRegisterPlatesRepositorie, RegisterPlatesRepositorie>();
builder.Services.AddAutoMapper(typeof(ConfigurationMapping));

#endregion

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
