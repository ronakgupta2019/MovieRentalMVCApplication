using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId==0 || customer.MembershipTypeId==1)
            
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.BirthDate.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Should be greater than 18 years to avail membership");
       
        }
    }
}