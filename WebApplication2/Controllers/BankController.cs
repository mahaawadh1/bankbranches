using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BankController : Controller
    {
        private static List<BankBranch> bankBranches = new List<BankBranch>()
        {
            new BankBranch{Id = 1, LocationName = "jaber AlAhmad", LocationURL = "https://www.google.com/maps/place/%D8%A8%D9%8A%D8%AA+%D8%A7%D9%84%D8%AA%D9%85%D9%88%D9%8A%D9%84+%D8%A7%D9%84%D9%83%D9%88%D9%8A%D8%AA%D9%8A+-+%D9%81%D8%B1%D8%B9+%D8%AC%D8%A7%D8%A8%D8%B1+%D8%A7%D9%84%D8%A3%D8%AD%D9%85%D8%AF%E2%80%AD/@29.3437559,47.7645498,17z/data=!3m1!4b1!4m6!3m5!1s0x3fcf8d49e0ab000b:0xa7ba40fa8597f760!8m2!3d29.3437512!4d47.7671247!16s%2Fg%2F11l1yvf1ht?entry=ttu" ,BranchManager
            = "Omar", EmployeeCount = 30 },

            new BankBranch{Id = 10, LocationName = "Almasayel", LocationURL = "https://www.google.com/maps/place/%D8%A8%D9%8A%D8%AA+%D8%A7%D9%84%D8%AA%D9%85%D9%88%D9%8A%D9%84+%D8%A7%D9%84%D9%83%D9%88%D9%8A%D8%AA%D9%8A+-+%D9%81%D8%B1%D8%B9+%D8%B5%D8%A8%D8%A7%D8%AD+%D8%A7%D9%84%D8%B3%D8%A7%D9%84%D9%85%E2%80%AD/@29.2585155,48.0427486,14z/data=!4m10!1m2!2m1!1z2KjZitiqINin2YTYqtmF2YjZitmEINin2YTZg9mI2YrYqtmKIG5lYXIg2KfZhNmF2LPYp9mK2YQ!3m6!1s0x3fcf9f82caa9454d:0x9edff5ffd7816198!8m2!3d29.2585155!4d48.0767382!15sCjjYqNmK2Kog2KfZhNiq2YXZiNmK2YQg2KfZhNmD2YjZitiq2YogbmVhciDYp9mE2YXYs9in2YrZhCIDiAEBkgEEYmFua-ABAA!16s%2Fg%2F1hdz3mjw4?entry=ttu" ,BranchManager
            = "Nawaf", EmployeeCount = 30 }
        };



        public IActionResult Index()
        {
            var context = new BankContext();
            return View(context.BankBranches.ToList());
        }


        public IActionResult Details(int id)
        {
            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Include(r=>r.Employees).SingleOrDefault(r=>r.Id == id);
                if (branch == null)
                {
                    return NotFound();
                }

                return View(branch);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var form = new NewBranchForm();

            return View(form);
        }

        [HttpPost]
        public IActionResult Create(NewBranchForm branchForm)
        {

            if (ModelState.IsValid)
            {
                using (var context = new BankContext())
                {
                    var newBranch = new BankBranch
                    {
                        LocationName = branchForm.LocationName,
                        LocationURL = branchForm.LocationURL,
                        BranchManager = branchForm.BranchManager,
                        EmployeeCount = branchForm.EmployeeCount

                    };

                    context.BankBranches.Add(newBranch);
                    context.SaveChanges();

                }



                return RedirectToAction("Index");
            }

            return View(branchForm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Find(id);
                if (branch == null)
                {
                    return RedirectToAction("Index");
                }
                var form = new NewBranchForm();
                form.LocationURL = branch.LocationURL;
                form.BranchManager = branch.BranchManager;
                form.LocationName = branch.LocationName;
                form.EmployeeCount = branch.EmployeeCount;

                return View(form);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, NewBranchForm newBranchForm)
        {

            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Find(id);
                if (branch != null)
                {
                    branch.LocationName = newBranchForm.LocationName;
                    branch.LocationURL = newBranchForm.LocationURL;
                    branch.BranchManager = newBranchForm.BranchManager;
                    branch.EmployeeCount = newBranchForm.EmployeeCount;
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var context = new BankContext())
            {
                    var branch = context.BankBranches.Find(id);
                    if (branch == null)
                    {
                    return RedirectToAction("Index");
                }

                    return View(branch);
                }
            
           
            }

        [HttpPost]
        public IActionResult Delete(int id, BankBranch b)
        {
            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Find(id);
                if (branch == null)
                {
                    return RedirectToAction("Index");
                }

                context.BankBranches.Remove(branch);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult AddEmployee(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm form)
        {
            if (ModelState.IsValid)
            {
                var database = new BankContext();
                var branch = database.BankBranches.Find(id);
                var newEmployee = new Employee();

                newEmployee.Name = form.Name;
                newEmployee.CivilId = form.CivilId;
                newEmployee.Position = form.Position;
                branch.Employees.Add(newEmployee);

                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);



        }




    }

}