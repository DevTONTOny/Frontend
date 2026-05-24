var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(
   opciones =>
   {
       opciones.AddPolicy(name: "Default",
       policy =>
       {
           policy.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();
       });
   }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Default");

app.UseAuthorization();


app.MapControllers();

app.Run();
