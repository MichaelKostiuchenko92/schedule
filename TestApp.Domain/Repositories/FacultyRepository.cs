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
    public class FacultyRepository : IRepository<Faculty>
    {
        private readonly Context _context;

        public FacultyRepository(Context _context)
        {
            this._context = _context;
        }

        public void Create(Faculty item)
        {
            _context.Facultys.Add(item);
        }

        public void Delete(int id)
        {
            _context.Facultys.Remove(_context.Facultys.Find(id));
        }

        public Faculty Get(int id)
        {
            return _context.Facultys.Find(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
          return  _context.Facultys;
        }

        public void Update(Faculty item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
