using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MusicianInvoiceGenerator.ViewModels.ValidationRules
{
    public class RateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string num = value as string ?? string.Empty;
            if (!double.TryParse(num, out double result))
            {
                return new ValidationResult(false, "Invalid entry. Please enter a valid number.");
            }
            if (result < 0)
            {
                return new ValidationResult(false, "The rate charged must be positive.");
            }
            if (!CheckDigitFormat(2, num))
            {
                return new ValidationResult(false, "If pence are to be included, they must be 2 digits only.");
            }
            return ValidationResult.ValidResult;
        }
        private bool CheckDigitFormat(int digits, string num)
        {
            if (num.Contains('.'))
            {
                string[] subs = num.ToString().Split('.');
                if (subs[1].Length != digits)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
