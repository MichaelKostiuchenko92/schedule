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
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly Context _context;

        public TeacherRepository(Context _context)
        {
            this._context = _context;
        }

        public void Create(Teacher item)
        {
            _context.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            _context.Teachers.Remove(_context.Teachers.Find(id));
        }

        public Teacher Get(int id)
        {
            return _context.Teachers.Find(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }

        public void Update(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
