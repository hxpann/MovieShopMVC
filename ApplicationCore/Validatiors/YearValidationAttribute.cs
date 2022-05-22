﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Validatiors
{
    public class YearValidationAttribute: ValidationAttribute
    {
        public YearValidationAttribute(int year)
        {
            Year = year;
        }
        public int Year { get; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userEnteredYear = ((DateTime)value).Year;

            if (userEnteredYear < Year)
            {
                return new ValidationResult("Please enter correct year");
            }    
            return ValidationResult.Success;
        }
    }
}
