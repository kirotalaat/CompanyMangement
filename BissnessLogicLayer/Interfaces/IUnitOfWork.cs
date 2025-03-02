using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Interfaces
{
    public interface IUnitOfWork 
    {
        public  IEmployeeReprosatory EmployeeReprosatory { get; set; }
        public  IDepartmentReprosatory DepartmentReprosatory { get; set; }

        public int Complete();



    }
}
