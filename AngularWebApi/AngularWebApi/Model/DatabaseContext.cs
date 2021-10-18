using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApi.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CategoryMst> Categories { get; set; }
    }
}
