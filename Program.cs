//Crea una aplicacion web 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Indica el uso de controladores
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//construye la aplicacion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Redirecciona a https de manera predeterminada
app.UseHttpsRedirection();

//Habilita el manejo de roles
app.UseAuthorization();

//Habilita el manejo de controladores
app.MapControllers();

//Ejecuta la aplicacion
app.Run();
