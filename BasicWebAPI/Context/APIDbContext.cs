using BasicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.Context
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
