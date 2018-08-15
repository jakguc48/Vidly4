using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    //180815_1_14:45 klasa bedzie dziedziczyła po Validation Attribute
    public class Min18YearsIFAMember : ValidationAttribute
    {
        //nadpisujemy klase Isvalid z context
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //castujemy kontekst na obiekt Customer 
            var customer = (Customer) validationContext.ObjectInstance;

            //jesli pay as you go albo nic to jest okej
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate jest polem wymaganym");
            }
            //wyliczenie wieku
            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 y.o. to buy licence");




        }
    }
}