using GenericCrud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericCrud.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Itens => Set<Item>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Carro> Carros => Set<Carro>();
    public DbSet<Venda> Vendas => Set<Venda>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CPF único: o banco impede dois clientes com o mesmo CPF
        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Cpf)
            .IsUnique();

        // Venda -> Cliente (N:1). Restrict = não deixa apagar cliente que tem venda
        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Cliente)
            .WithMany(c => c.Vendas)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Venda -> Carro (N:1)
        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Carro)
            .WithMany()
            .HasForeignKey(v => v.CarroId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}