using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Agregar el DbContext con la cadena de conexión
builder.Services.AddDbContext<SemaforosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Agregar servicios de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
