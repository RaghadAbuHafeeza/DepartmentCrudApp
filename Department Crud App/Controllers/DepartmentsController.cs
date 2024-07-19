using Department_Crud_App.Data;
using Department_Crud_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Department_Crud_App.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext context;

        public DepartmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var department = context.Departments.ToList();
            return View(department);
        }
        public IActionResult Details(int id)
        {
            var department = context.Departments.Find(id);
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
