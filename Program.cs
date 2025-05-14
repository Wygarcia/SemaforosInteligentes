using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Models;
using System.Text.Json.Serialization;
using SemaforosInteligentes.Converters;

var builder = WebApplication.CreateBuilder(args);

// ✅ Agregar el DbContext con la cadena de conexión
builder.Services.AddDbContext<SemaforosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// ✅ Agregar servicios de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });

var app = builder.Build();

// ✅ Ejecutar inicialización de datos si lo deseas (opcional)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SemaforosDbContext>();
    // Aquí puedes insertar datos si tienes la clase DbInitializer
    // DbInitializer.Initialize(context);
}

// ✅ Configurar el pipeline HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
