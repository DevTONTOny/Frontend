using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// --- SERVICIOS ---
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Política CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy
            .AllowAnyOrigin()  // o usa WithOrigins("http://localhost:4200") si tu Angular corre ahí
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAlmacenamiento, Almacenamiento>();
// Configuración del contexto de base de datos
builder.Services.AddDbContext<DbEscuelaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgresConnection"))
);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = 
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// --- CONSTRUCCIÓN DE APP ---
var app = builder.Build();

// --- MIDDLEWARE ---
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 🚨 CORS DEBE IR ANTES DE MAPCONTROLLERS Y AUTORIZACIÓN
app.UseCors("Default");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
