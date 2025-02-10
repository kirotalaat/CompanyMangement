using Microsoft.AspNetCore.Mvc;
using BissnessLogicLayer.Interfaces;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeReprosatory EmployeeContext;
        private readonly IDepartmentReprosatory departmentContext;

        public EmployeeController(IEmployeeReprosatory employeeReprosatory , IDepartmentReprosatory departmentReprosatory)
        {
            EmployeeContext = employeeReprosatory;
            departmentContext = departmentReprosatory;
        }


        public IActionResult Index()
        {
            var employees = EmployeeContext.GettAll();
            return View(employees);
        }

        public IActionResult Create() {

            var departments = departmentContext.GettAll();
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {

                int result =  EmployeeContext.Add(employee);
                if (result > 0)
                    TempData["Message"] = "Employee is created ";
                return RedirectToAction(nameof(Index));


            }
            ViewBag.Departments = departmentContext.GettAll();
            return View(employee);
        }






        public IActionResult Deatails( int? id, string view = "Deatails") {
            if (id == null)
                return BadRequest();
            var employee = EmployeeContext.GetById(id.Value);
            if (employee == null)
                return NotFound();
            return View(view,employee);
        }


      
        
        
        public IActionResult Edit(int?id) {

            return Deatails(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee , [FromRoute] int id  , string view = "Edit" ) {
        
            if (id != employee.Id)
                return BadRequest();
        if (ModelState.IsValid)
            {
                try
                {
                    EmployeeContext.Update(employee);
                    return RedirectToAction(nameof (Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            
        return View(view,employee);
        
        }

   
        
        
        
        public IActionResult Delete(int id) {
            return Deatails(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete( [FromRoute]int id , Employee employee ) { 
        

            if (id != employee.Id)
                return BadRequest();
        if (ModelState.IsValid)
            {
                try {
                
                EmployeeContext.Delete(employee);
                return RedirectToAction(nameof (Index));
                
                
                
                }
                catch (Exception ex) {


                    ModelState.AddModelError(string.Empty, ex.Message);

                
                }
            


            }
            return View(employee);

        }






    }
}
