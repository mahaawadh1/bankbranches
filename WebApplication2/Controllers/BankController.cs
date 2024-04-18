using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BankController : Controller
    {
        private static List<BankBranch> bankBranches = new List<BankBranch>()
        {
            new BankBranch{Id = 50, LocationName = "Almsayel", LocationURL = "https://www.google.com/maps/dir/29.3334544,48.0673006/%D8%A8%D9%8A%D8%AA+%D8%A7%D9%84%D8%AA%D9%85%D9%88%D9%8A%D9%84+%D8%A7%D9%84%D9%83%D9%88%D9%8A%D8%AA%D9%8A,+Hamad+Alkhaled+St,+kuwait%E2%80%AD%E2%80%AD/@29.3300826,47.9542369,12z/data=!3m1!4b1!4m9!4m8!1m1!4e1!1m5!1m1!1s0x3fcf9ca79161387b:0x30210b1335d485e4!2m2!1d48.0016982!2d29.3507565?entry=ttu" ,BranchManager
            = "omar", EmployeeCount = 30 },

            new BankBranch{Id = 10, LocationName = "jaber alahmed ", LocationURL = "https://www.google.com/maps/dir/29.3334544,48.0673006/%D8%A8%D9%8A%D8%AA+%D8%A7%D9%84%D8%AA%D9%85%D9%88%D9%8A%D9%84+%D8%A7%D9%84%D9%83%D9%88%D9%8A%D8%AA%D9%8A,+Hamad+Alkhaled+St,+kuwait%E2%80%AD%E2%80%AD/@29.3300826,47.9542369,12z/data=!3m1!4b1!4m9!4m8!1m1!4e1!1m5!1m1!1s0x3fcf9ca79161387b:0x30210b1335d485e4!2m2!1d48.0016982!2d29.3507565?entry=ttu" ,BranchManager
            = "nawaf", EmployeeCount = 17 }
        };



        public IActionResult Index()
        {

            return View(bankBranches);
        }


        public IActionResult Details(int id)
        {
            var branch = bankBranches.FirstOrDefault(b => b.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
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
                var newBranch = new BankBranch
                {
                    LocationName = branchForm.LocationName,
                    LocationURL = branchForm.LocationURL,
                    BranchManager = branchForm.BranchManager,
                    EmployeeCount = branchForm.EmployeeCount
                };
                bankBranches.Add(newBranch);


                return RedirectToAction("Index");
            }

            return View(branchForm);
        }

        
    }
}




