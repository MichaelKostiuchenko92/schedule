using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Faculty> Facultys { get; }
        IRepository<Specialty> Specialtys { get; }

        void Save();
    }
}
