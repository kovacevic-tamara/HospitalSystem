﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace upravnikKT2.Validation
{
    class MinimumCharactersRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            if (charString.Length < MinimumCharacters)
                return new ValidationResult(false, $"Use at least {MinimumCharacters} characters");

            return new ValidationResult(true, null);
        }
    }
}
