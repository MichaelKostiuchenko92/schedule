using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain
{
    public class Context : DbContext
    {
        public Context() : base("Connection")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }
    }
}
