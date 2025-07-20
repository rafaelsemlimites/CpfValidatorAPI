using Microsoft.OpenApi.Models;
using CpfValidatorAPI.Services.Interfaces;
using CpfValidatorAPI.Services;



var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços de controllers
builder.Services.AddControllers();

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger configurado
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cpf Validator API",
        Version = "v1"
    });
});

builder.Services.AddScoped<ICpfValidatorService, CpfValidatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cpf Validator API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowVueApp");
app.MapControllers();
app.Run();
