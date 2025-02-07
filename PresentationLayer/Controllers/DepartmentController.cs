using Microsoft.AspNetCore.Mvc;
using  BissnessLogicLayer.Interfaces;
using DataAcessLayer.Models;
namespace PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentReprosatory context ;

        public DepartmentController(IDepartmentReprosatory _context)
        {
            context = _context ;
        }

        public IActionResult Index()
        {

            var departments = context.GettAll();
            return View(departments);
        }
       

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Department department)
        {

            if (ModelState.IsValid)
            {
                context.Add(department);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(department);

        }
       
        public IActionResult Deatails(int? id , string view = "Deatails") {

            if (id == null )
            {
                return BadRequest();
            }


            var deparetment = context.GetById(id.Value);
            if (deparetment == null) { 
            return NotFound();
            }
            return View(view,deparetment);
        }

        public IActionResult Edit(int? id) { 
            
        //if (id == null) { return BadRequest(); }

        //var department = context.GetById(id.Value);
        //    if (department == null) {

        //        return NotFound();
        //    }
            return Deatails(id,"Edit");
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department,[FromRoute]int id)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid) {

                try
                {
                    context.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(department);
        }
        
        public IActionResult Delete(int? id) { 
        
            if(id == null)
            {
                return BadRequest();
            }
            var department = context.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        [HttpPost]
        public IActionResult Delete(Department department , [FromRoute] int id)
        {
            if(department.Id != id)
                return BadRequest();
            
            if (ModelState.IsValid)
                try
                {
                    context.Delete(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty,ex.Message);
                }
            return View(department);


                

        }

    }
}
