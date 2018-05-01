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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper mapper;

        public TeacherService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            this.mapper = mapper;
        }

        public IEnumerable<TeacherView> GetTeacherViews()
        {
            List<Teacher> teachers = _db.Teachers.GetAll().ToList();
            return mapper.Map<List<Teacher>, List<TeacherView>>(teachers);
        }

        public TeacherView GetTeacherView(int id)
        {
            Teacher teacher = _db.Teachers.Get(id);
            return mapper.Map<Teacher, TeacherView>(teacher);
        }

        public void CreateTeacher(TeacherView teacherView)
        {
            var teacher = mapper.Map<TeacherView, Teacher>(teacherView);
            _db.Teachers.Create(teacher);
            _db.Save();
        }

        public void UpdateTeacher(TeacherView teacherView)
        {
            var teacher = mapper.Map<TeacherView, Teacher>(teacherView);
            _db.Teachers.Update(teacher);
            _db.Save();
        }

        public void DeleteTeacher(int id)
        {
            _db.Teachers.Delete(id);
            _db.Save();
        }
    }
}
