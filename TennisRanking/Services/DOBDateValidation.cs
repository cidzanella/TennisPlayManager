using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Services
{
    public class DOBDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else 
            { 
                return new ValidationResult("Data Inválida");
            }

            var min = DateTime.Now.AddYears(-5);
            var max = DateTime.Now.AddYears(-90);
            var msg = string.Format("Por gentileza, informe uma data entre {0:MM/dd/yyyy} e {1:MM/dd/yyyy}", max, min);
            
            try
            {
                if (date > min || date < max)
                    return new ValidationResult(msg);
                else
                    return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }
    }
}
