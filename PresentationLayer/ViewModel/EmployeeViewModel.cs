using DataAcessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Lenght is 50")]
        [MinLength(3, ErrorMessage = "Min Lenght is 3")]
        public string Name { get; set; }

        [Range(22, 35, ErrorMessage = "Age must be In Range From 22 to 35")]
        public int? Age { get; set; }





        [RegularExpression(@"^\d{1,5}-[a-zA-Z\s]+-[a-zA-Z\s]+-[a-zA-Z\s]+$", ErrorMessage = "Address must be in the format: 123-street-city-country")]

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }


        //[InverseProperty(nameof(Department.Employees))]

        //[ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
