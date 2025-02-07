using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Interfaces
{
    public interface IEmployeeReprosatory : IGenericReprosatory<Employee>
    {
        IQueryable<Employee> GetEmployeesByAddress(string address);
                
    }
}
