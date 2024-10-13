using System;
using System.ComponentModel.DataAnnotations;

public class DecimalPrecisionAttribute : ValidationAttribute
{
    private readonly int _precision;
    private readonly int _scale;

    public DecimalPrecisionAttribute(int precision, int scale)
    {
        _precision = precision;
        _scale = scale;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Allow null values if needed
        }

        if (value is decimal decimalValue)
        {
            var stringValue = decimalValue.ToString("G29");
            var splitValue = new string[2];
            if (stringValue.Contains(','))
            {
                splitValue = stringValue.Split(',');
            }
            else if (stringValue.Contains('.'))
            {
                splitValue = stringValue.Split('.');
            }
            else
            {
                if(stringValue.Length > 10)
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} must not exceed {_precision} digits in total.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            // Check precision
            if (splitValue[0].Length > (_precision - _scale))
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must not exceed {_precision} digits in total.");
            }

            // Check scale
            if (splitValue.Length > 1 && splitValue[1].Length > _scale)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must have a maximum of {_scale} decimal places.");
            }
        }

        return ValidationResult.Success;
    }
}
