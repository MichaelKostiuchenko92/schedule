using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ViewModels.Models;

namespace TestApp.BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentView> GetStudentViews();
        StudentView GetStudentView(int id);
        void CreateStudent(StudentView studentView);
        void UpdateStudent(StudentView studentView);
        void DeleteStudent(int id);
    }
}
