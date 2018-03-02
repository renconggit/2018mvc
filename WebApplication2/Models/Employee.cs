using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        
        public int EmployeeId { get; set; }
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(5, ErrorMessage = "不超过5位的名子  asd ")]
        public string LastName { get; set; }
        public int? Salary { get; set; }
    }
}