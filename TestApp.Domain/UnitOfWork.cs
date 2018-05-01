using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Interfaces;
using TestApp.Domain.Repositories;

namespace TestApp.Domain
{
    public class UnitOfWork : IUnitOfWork

    {
        private Context _db;
        private StudentRepository studentRepository;
        private TeacherRepository teacherRepository;
        private FacultyRepository facultyRepository;
        private SpecialtyRepository specialtyRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            _db = new Context();
        }

        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(_db);
                }
                return studentRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (teacherRepository == null)
                {
                    teacherRepository = new TeacherRepository(_db);
                }
                return teacherRepository;
            }

        }

        public IRepository<Faculty> Facultys
        {
            get
            {
                if (facultyRepository == null)
                {
                    facultyRepository = new FacultyRepository(_db);
                }
                return facultyRepository;
            }
        }

        public IRepository<Specialty> Specialtys
        {
            get
            {
                if (specialtyRepository == null)
                {
                    specialtyRepository = new SpecialtyRepository(_db);
                }
                return specialtyRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
