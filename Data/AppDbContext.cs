using GenericCrud.API.Models;
using Microsoft.EntityFrameWorkCore;

namespace GenericCrud.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextoptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Item> Itens {get; set;}
}