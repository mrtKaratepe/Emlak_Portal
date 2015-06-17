using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Ltd.NA.Emlak.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof (DatabaseContext).Assembly);
        }
    }
}
