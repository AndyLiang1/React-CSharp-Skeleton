using Microsoft.EntityFrameworkCore; 

namespace Server.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {

    }

    public DbSet<TodoItem> TodoItems {get; set;} = null!;
    public DbSet<TodoItem> Note {get; set;} = null!;
    public DbSet<Note2> Note2s {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasMany(e => e.Notes)
            .WithOne(e => e.TodoItem)
            .HasForeignKey(e => e.TodoItemId)
            .IsRequired();
    }
}