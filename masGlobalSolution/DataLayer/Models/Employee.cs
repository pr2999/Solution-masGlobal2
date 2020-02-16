using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Employee
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

        [Display(Name = "hourlySalary salary")]
        [Required(ErrorMessage = "hourlySalary is required ")]
        public Decimal hourlySalary { get; set; }

        [Display(Name = "monthly salary")]
        [Required(ErrorMessage = "monthlySalary is required ")]
        public decimal monthlySalary { get; set; }
        public decimal anualySalary { get; set; }

    }
}