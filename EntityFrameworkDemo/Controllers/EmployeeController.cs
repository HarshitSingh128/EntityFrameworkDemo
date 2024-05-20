using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db;
        EmployeeDAL empdal;

        public EmployeeController(ApplicationDbContext db)
        {
        this.db = db;
            empdal=new EmployeeDAL(this.db);
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = empdal.GetEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)

        {
            var model = empdal.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int res = empdal.AddEmployee(emp);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = empdal.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int res = empdal.EditEmployees(emp);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = empdal.GetEmployeeById(id);
            return View(model);

        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deleteform(int id)
        {
            try
            {
                int res = empdal.DeleteEmployee(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
