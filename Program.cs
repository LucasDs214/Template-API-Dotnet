using GenericCrud.API.Data;
using GenericCrud.API.Interfaces;
using GenericCrud.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura o SQLite (vai criar um arquivo banco.db)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=banco.db"));

// 2. Injeção de Dependência dos Serviços
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Garante que o banco seja criado automaticamente ao rodar a API
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
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