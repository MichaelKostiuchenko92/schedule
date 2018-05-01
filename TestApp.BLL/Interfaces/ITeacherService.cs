using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ViewModels.Models;

namespace TestApp.BLL.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<TeacherView> GetTeacherViews();
        TeacherView GetTeacherView(int id);
        void CreateTeacher(TeacherView teacherView);
        void UpdateTeacher(TeacherView teacherView);
        void DeleteTeacher(int id);
    }
}
