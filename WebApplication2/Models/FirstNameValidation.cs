using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please Provide First Name");
            }
            else 
            {
                if (value.ToString().Contains("@")) 
                {
                    return new ValidationResult("First Name should contain @");
                }
            }
            return ValidationResult.Success;
        }
    }
}