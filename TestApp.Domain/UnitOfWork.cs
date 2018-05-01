using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Repositories;

namespace TestApp.Domain
{
    public class UnitOfWork : IDisposable

    {
        private Context _db = new Context();
        private StudentRepository studentRepository;
        private TeacherRepository teacherRepository;
        private FacultyRepository facultyRepository;
        private SpecialtyRepository specialtyRepository;

        private bool disposed = false;

        public StudentRepository Students
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

        public TeacherRepository Teachers
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

        public FacultyRepository Facultys
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

        public SpecialtyRepository Specialtys
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
