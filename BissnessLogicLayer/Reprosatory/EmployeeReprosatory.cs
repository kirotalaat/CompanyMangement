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
    public class EmployeeReprosatory : GenericReprosatory<Employee> , IEmployeeReprosatory
    {

        private readonly CompanyMangementDbcontext _dbcontext;

        public EmployeeReprosatory( CompanyMangementDbcontext dbcontext):base(dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public IQueryable<Employee> GetEmployeesByAddress(string address)
        => _dbcontext.Employees.Where(E => E.Address == address);
        
    }
}
