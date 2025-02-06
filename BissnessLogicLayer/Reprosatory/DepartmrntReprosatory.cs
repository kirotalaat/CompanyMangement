using BissnessLogicLayer.Interfaces;
using DataAcessLayer;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Reprosatory
{


    public class DepartmrntReprosatory : GenericReprosatory<Department> , IDepartmentReprosatory
    {
      //  private readonly CompanyMangementDbcontext _context;

        public DepartmrntReprosatory(CompanyMangementDbcontext context):base(context)
        {
            //_context = context;
        }

        //public int Add(Department department)
        //{
        //    _context.Add(department);
        //    return _context.SaveChanges();
        //}
        //public int Update(Department department)
        //{
        //    _context.Departments.Update(department);
        //    return _context.SaveChanges();

        //}

        //public int Delete(Department department)
        //{
        //    _context.Remove(department);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Department> GetAll()
        //{
        //    var departments = _context.Departments.ToList();
        //    return departments;
        //}

        //public Department GetById(int id)
        //{
        //    //var department = _context.Departments.Local.Where(D=>D.Id == id).FirstOrDefault();
        //    //if (department is null) {
        //    //     department = _context.Departments.Where(D => D.Id == id).FirstOrDefault();
        //    //}
        //    //return department;
        //    var department = _context.Departments.Find(id);
        //    return department;
        //}






























    }
}
