using GenericCrud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericCrud.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Item> Itens {get; set;}
}