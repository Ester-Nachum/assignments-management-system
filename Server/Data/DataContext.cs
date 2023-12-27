using Assignments.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Assignment> Assignments { get; set; }
    }
}