using ExamenTema2.MyHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSignalR();
builder.Services.AddCors(
   opciones =>
   {
       opciones.AddPolicy(name: "Default",
       policy =>
       {
           policy.WithOrigins("http://127.0.0.1:5500","http://127.0.0.1:5501","http://127.0.0.1:5500")
           .AllowAnyMethod()
           .AllowAnyHeader();
       });
   }
);
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapHub<MyHub>("/MapacheWebSocketServer");
app.UseHttpsRedirection();

app.UseCors("Default");

app.UseAuthorization();

app.MapControllers();

app.Run();
