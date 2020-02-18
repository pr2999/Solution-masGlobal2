using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class EmployeeViewModel
    {

        [Key]
        [MaxLength(1), MinLength(1)]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required"), MaxLength(15)]
        [StringLength(15)]
        [Display(Name = "Employee name")]
        public string name { get; set; }

        [Required(ErrorMessage = "contractTypeName is required"), MaxLength(20)]
        [StringLength(20)]
        public string contractTypeName { get; set; }

        [Required]
        [StringLength(1)]

        public int roleId { get; set; }

        [Required(ErrorMessage = "Role name is required ")]
        [Display(Name = "Role name")]
        public string roleName { get; set; }

        public string roleDescription { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public Decimal anualSalary { get; set; }

    }
}
