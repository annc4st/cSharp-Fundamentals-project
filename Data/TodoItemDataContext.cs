using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TodoList2.Data
{
    public class TodoItemDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public TodoItemDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("todoListDB"));
        }
// just adding a table to existing db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
                modelBuilder.Entity<TodoItem>()
                    .HasData(
                        new TodoItem
                        {
                            Id = 1,
                            Text = "read a book",
                            Completed = false,
                        }
                    );

            modelBuilder.Entity<Invoice>().ToTable("InvoicesTable");
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice {
                    Id = 1,
                    Details = "Test init invoice",
                    ToFrom = "testing partner",
                    Amount = 100,
                }
            );

            modelBuilder.Entity<Payment>().ToTable("PaymentsTable");
            modelBuilder.Entity<Payment>().HasData(
                new Payment {
                    Id = 1,
                    Details = "Test init Payment",
                    ToFrom = "testing partner",
                    Amount = 100,
                }
            );
        }

        public DbSet<TodoItem> TodoItems { get; set;}
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}



