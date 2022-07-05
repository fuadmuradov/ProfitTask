using Microsoft.EntityFrameworkCore;
using Profit.Core.Entities;
using Profit.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Data
{
    public class ProfitDbContext:DbContext
    {
        public ProfitDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }

        }
}
