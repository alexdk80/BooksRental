using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksRental.Models
{
    public class Min18YearsIfMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId==MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate==null)
            {
                return new ValidationResult("Birthday is required.");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 yeas old to go to a memership. ");
        }

    }
}