using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class MovieNumberInStockReq : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if (movie.NumberInStock <= 0 || movie.NumberInStock > 20)
            {
                return new ValidationResult("Ilosc kopii musi być liczba w przedziale od 1 do 20");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}