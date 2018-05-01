using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Interfaces;

namespace TestApp.Domain.Repositories
{
    public class SpecialtyRepository : IRepository<Specialty>
    {
        private readonly Context _context;

        public SpecialtyRepository(Context _context)
        {
            this._context = _context;
        }

        void IRepository<Specialty>.Create(Specialty item)
        {
            _context.Specialtys.Add(item);
        }

        void IRepository<Specialty>.Delete(int id)
        {
            _context.Specialtys.Remove(_context.Specialtys.Find(id));
        }

        Specialty IRepository<Specialty>.Get(int id)
        {
            return _context.Specialtys.Find(id);
        }

        IEnumerable<Specialty> IRepository<Specialty>.GetAll()
        {
            return _context.Specialtys;
        }

        void IRepository<Specialty>.Update(Specialty item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
