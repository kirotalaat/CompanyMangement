using BissnessLogicLayer.Interfaces;
using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Reprosatory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyMangementDbcontext _dbcontext;

        public IEmployeeReprosatory EmployeeReprosatory { get ; set ; }
        public IDepartmentReprosatory DepartmentReprosatory { get; set; }
        

        
        public UnitOfWork(CompanyMangementDbcontext dbcontext)
        {
            EmployeeReprosatory = new EmployeeReprosatory(dbcontext);
            DepartmentReprosatory  =new DepartmrntReprosatory(dbcontext);
            _dbcontext = dbcontext;
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();

        }



    }
}
