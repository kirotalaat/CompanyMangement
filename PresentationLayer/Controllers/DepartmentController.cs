using Microsoft.AspNetCore.Mvc;
using  BissnessLogicLayer.Interfaces;
using DataAcessLayer.Models;
namespace PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {

        //private readonly IDepartmentReprosatory context ;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(/*IDepartmentReprosatory _context*/ IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            var departments = _unitOfWork.DepartmentReprosatory.GettAll();
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

                
                _unitOfWork.DepartmentReprosatory.Add(department);
                int Result = _unitOfWork.Complete();
                if (Result > 0)
                    TempData["Message"] = "Department is created";
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


            var deparetment = _unitOfWork.DepartmentReprosatory.GetById(id.Value);
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
                    _unitOfWork.DepartmentReprosatory.Update(department);
                    _unitOfWork.Complete();
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
            var department = _unitOfWork.DepartmentReprosatory.GetById(id.Value);
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
                    _unitOfWork.DepartmentReprosatory.Delete(department);
                    _unitOfWork.Complete();
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
