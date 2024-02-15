using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppViewbagViewData_TempData.Models;

namespace WebAppViewbagViewData_TempData.Controllers
{
    public class EmpController : Controller
    {
        static List<Emp> listEmp = new List<Emp>

    {

        new Emp{ Id=1, Name="Sam", Salary=98000, Designation="Manager"},
        new Emp{ Id=2, Name="Anil" , Salary=86000, Designation="Developer"},
        new Emp{ Id=3, Name="Vini", Salary=98000, Designation="Manager"},
        new Emp{ Id=4, Name="Viz", Salary=78000, Designation="Developer" },
        new Emp{ Id=5, Name="Dipesh", Salary=65000, Designation="Tester"},
    };

        // GET: Emp
        public ActionResult Index()
        {
            ViewBag.msg = "welcome to employee management";
            ViewBag.noEmp = listEmp.Count;
            return View(listEmp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["msg"] = "Employee Registration";
            return View(new Emp());
        }
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                listEmp.Add(emp);
                TempData["tempmsg"] = "New Employee Registeration Success";
                return RedirectToAction("Index");
            }
            else
            {

                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
            Emp emp = listEmp.SingleOrDefault(e => e.Id == id);
            return View(emp);

        [HttpPost]
        public ActionResult Delete(int? id)
        Emp emp = listEmp.SingleOrDefault(e => e.Id == id); 
        if (emp != null)
            ListEmp.Remove(emp);
            return RedirectYoAction("Index");

    }
}
