using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.BLL.Interfaces;
using TestApp.ViewModels.Models;

namespace TestApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }
        // GET: Teacher
        public ActionResult Index()
        {
            IEnumerable<TeacherView> teachertViews = _service.GetTeacherViews();
            return View("Index", teachertViews);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            TeacherView teachertView = _service.GetTeacherView(id);
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(TeacherView teacherView)
        {
            _service.CreateTeacher(teacherView);
            return RedirectToAction("Index");
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            TeacherView teacher = _service.GetTeacherView(id);
            if (teacher != null)
            {
                return View("Edit");
            }
            return HttpNotFound();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(TeacherView teacher)
        {
            try
            {
                _service.UpdateTeacher(teacher);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(teacher);
            }
        }


        // POST: Teacher/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _service.DeleteTeacher(id);
            return RedirectToAction("Index");
        }
    }
}
