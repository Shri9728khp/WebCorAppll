using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebCorAppll.DB_Context;
using WebCorAppll.Models;

namespace WebCorAppll.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      

       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StudentdataContext obj = new StudentdataContext();
             var res = obj.Employees.ToList();

            return View(res);

        }
      
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(MyClass obj)
        {
            StudentdataContext obj1 = new StudentdataContext();
            var log = obj1.Logintables.Where(m => m.Email == obj.Email).FirstOrDefault();
            if(log==null)
            {
                TempData["email"] = "invalid ";
            }
            else
            {
                if(log.Email==obj.Email && log.Email==obj.Email)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["pass"] = "invalid ";
                }
            }
         

            return View();
        }
            
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]


        public IActionResult Form(Dd_Contex obj1)
        {
            StudentdataContext obj = new StudentdataContext();
            Employee obj2 = new Employee();

            obj2.Id = obj1.Id;
            obj2.Name = obj1.Name;
            obj2.Rollno = obj1.Rollno;
            obj2.Email = obj1.Email;
            obj2.Mobile = obj1.Mobile;
            obj2.Address = obj1.Address;
            obj2.Gender = obj1.Gender;
            if (obj1.Id == 0)
            {
                obj.Employees.Add(obj2);
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                obj.Entry(obj2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
        public IActionResult Delete(int Id)
        {
            StudentdataContext obj = new StudentdataContext();
            var del = obj.Employees.Where(m => m.Id == Id).FirstOrDefault();
            
            obj.Employees.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult edit(int Id)
        {
            StudentdataContext obj = new StudentdataContext();

            Employee obj2 = new Employee();
            var edit = obj.Employees.Where(m => m.Id == Id).First();
            obj2.Id = edit.Id;
            obj2.Name = edit.Name;
            obj2.Rollno = edit.Rollno;
            obj2.Email = edit.Email;
            obj2.Mobile = edit.Mobile;
            obj2.Address = edit.Address;
            obj2.Gender = edit.Gender;
            obj.SaveChanges();
            return View("form", obj2);




           
        }
    }
}
