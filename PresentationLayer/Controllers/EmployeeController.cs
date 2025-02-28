﻿using Microsoft.AspNetCore.Mvc;
using BissnessLogicLayer.Interfaces;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PresentationLayer.ViewModel;
using AutoMapper;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeReprosatory EmployeeContext;
        private readonly IDepartmentReprosatory departmentContext;
        private readonly IMapper mappper;

        public EmployeeController(IEmployeeReprosatory employeeReprosatory , IDepartmentReprosatory departmentReprosatory , IMapper mapper )
        {
            EmployeeContext = employeeReprosatory;
            departmentContext = departmentReprosatory;
            mappper = mapper;
        }


        public IActionResult Index(string SearchName)
        {
            IEnumerable<Employee> employees;
            
            if (string.IsNullOrEmpty(SearchName))
            {
                 employees = EmployeeContext.GettAll();
            }
           else
            {
                 employees = EmployeeContext.GetEmployeesBySearch(SearchName);
            }
              
            
            
            
            var MappedEmployee = mappper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployee);


        }

        public IActionResult Create() {

            var departments = departmentContext.GettAll();
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
               var MappedEmployee = mappper.Map<EmployeeViewModel , Employee>(employee);   
                int result =  EmployeeContext.Add(MappedEmployee);
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
            var MappedEmployee = mappper.Map<Employee, EmployeeViewModel>(employee);
            return View(view,MappedEmployee);
        }


      
        
        
        public IActionResult Edit(int?id) {

            return Deatails(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employee , [FromRoute] int id  , string view = "Edit" ) {
        
            if (id != employee.Id)
                return BadRequest();
        if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmployee=mappper.Map<EmployeeViewModel,Employee>(employee);
                    EmployeeContext.Update(MappedEmployee);
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
        public IActionResult Delete( [FromRoute]int id , EmployeeViewModel employee ) { 
        

            if (id != employee.Id)
                return BadRequest();
        if (ModelState.IsValid)
            {
                try {
                var MappedEmployee=mappper.Map<EmployeeViewModel,Employee>(employee);
                EmployeeContext.Delete(MappedEmployee);
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
