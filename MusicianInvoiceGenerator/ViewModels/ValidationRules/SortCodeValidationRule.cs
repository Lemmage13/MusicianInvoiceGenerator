using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MusicianInvoiceGenerator.ViewModels.ValidationRules
{
    public class SortCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sortCode = value as string ?? String.Empty;
            Regex scode = new Regex(@"^[0-9][0-9]-[0-9][0-9]-[0-9][0-9]$"); //regex for sort code format
            if(!scode.IsMatch(sortCode))
            {
                return new ValidationResult(false, "Sort Code not formatted correctly");
            }
            return ValidationResult.ValidResult;
        }
    }
}
