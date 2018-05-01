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
    public class StudentRepository : IRepository<Student>
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
        }

        public void Delete(int id)
        {
            _context.Students.Remove(_context.Students.Find(id));
        }

        public Student Get(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
