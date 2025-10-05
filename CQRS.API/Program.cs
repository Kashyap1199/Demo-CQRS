using CQRS.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection; // Add this

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR and explicitly add the CQRS.EF assembly
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssemblies(
//        Assembly.GetExecutingAssembly(),
//        typeof(ApplicationDbContext).Assembly
//    )
//);s


builder.Services.AddMediatR(
    Assembly.GetExecutingAssembly(),
    typeof(ApplicationDbContext).Assembly
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
