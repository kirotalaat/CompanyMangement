using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage ="Code is Required")]
        public String Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateCreation { get; set; }

        //[InverseProperty(nameof(Employee.Department))]
        public ICollection<Employee> Employees { get; set; } =new HashSet<Employee>();
    }
}
