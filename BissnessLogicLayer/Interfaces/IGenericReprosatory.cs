using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Interfaces
{
    public interface IGenericReprosatory<T> where T : class 
    {



        IEnumerable<T> GettAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);





    }
   

   
}
