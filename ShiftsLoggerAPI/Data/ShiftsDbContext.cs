using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ShiftsLoggerAPI.Data
{
    public class ShiftsDbContext(DbContextOptions<ShiftsDbContext> options) : DbContext(options)
    {
        public System.Data.Entity.DbSet<Shift>? Shifts { get; set; }
    }
}
