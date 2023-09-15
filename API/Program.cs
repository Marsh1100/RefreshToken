using API.Extension;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
builder.Services.AddJwt(builder.Configuration);


builder.Services.AddDbContext<RefreshTokenContext>(optionsBuilder => //Inyección del DB Context
{
    string  connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using(var scope= app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try{
    var context = services.GetRequiredService<RefreshTokenContext>();
    await context.Database.MigrateAsync();
    }
    catch(Exception ex){
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex,"Ocurrió un error durante la migración");
    }
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
