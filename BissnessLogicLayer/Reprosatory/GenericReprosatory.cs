using BissnessLogicLayer.Interfaces;
using DataAcessLayer;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnessLogicLayer.Reprosatory
{
    public class GenericReprosatory<T> : IGenericReprosatory<T> where T : class
    {

        private readonly CompanyMangementDbcontext _dbcontext;
        public GenericReprosatory( CompanyMangementDbcontext dbcontext )
        {
            _dbcontext = dbcontext;
        }



        public int Add(T item)
        {
             _dbcontext.Add(item);
             return _dbcontext.SaveChanges();
        }

        public int Delete(T item)
        {
            _dbcontext.Remove(item);
            return _dbcontext.SaveChanges();
        }

        public T GetById(int id)
        => _dbcontext.Set<T>().Find(id);
      

        public IEnumerable<T> GettAll()
        {
            if (typeof(T)==typeof (Employee))
            {
                return (IEnumerable<T>)_dbcontext.Employees.Include(E => E.Department).ToList(); 
            }

           return _dbcontext.Set<T>().ToList();
        }

        public int Update(T item)
        {
            _dbcontext.Update(item);
            return _dbcontext.SaveChanges();
        }
    }
}
