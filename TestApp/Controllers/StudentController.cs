using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Services;
using TestApp.ViewModels.Models;

namespace TestApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentView> studentViews = _service.GetStudentViews();
            return View("Index", studentViews);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentView studentView = _service.GetStudentView(id);
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentView studentView)
        {
            try
            {
                _service.CreateStudent(studentView);

                return RedirectToAction("Index");
            }
            catch   
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentView student = _service.GetStudentView(id);
            if (student != null)
            {
                return View("Edit");
            }
            return HttpNotFound();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentView studentView)
        {
            try
            {
                _service.UpdateStudent(studentView);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(studentView);
            }
        }


        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
                _service.DeleteStudent(id);
                return RedirectToAction("Index");
        }
    }
}
