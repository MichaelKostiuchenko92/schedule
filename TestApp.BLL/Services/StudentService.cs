using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Interfaces;
using TestApp.Domain.Entities;
using TestApp.Domain.Interfaces;
using TestApp.ViewModels.Models;

namespace TestApp.BLL.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _db;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            this.mapper = mapper;
        }

        public IEnumerable<StudentView> GetStudentViews()
        {
            List<Student> students = _db.Students.GetAll().ToList();
            return mapper.Map<List<Student>, List<StudentView>>(students);
        }

        public StudentView GetStudentView(int id)
        {
            Student student = _db.Students.Get(id);
            return mapper.Map<Student, StudentView>(student);
        }

        public void CreateStudent(StudentView studentView)
        {
            var student = mapper.Map<StudentView, Student>(studentView);
            _db.Students.Create(student);
            _db.Save();
        }

        public void UpdateStudent(StudentView studentView)
        {
            var student = mapper.Map<StudentView, Student>(studentView);
            _db.Students.Update(student);
            _db.Save();
        }

        public void DeleteStudent(int id)
        {
            _db.Students.Delete(id);
            _db.Save();
        }
    }
}
