using DataAcessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public String Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateCreation { get; set; }

        //[InverseProperty(nameof(Employee.Department))]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
