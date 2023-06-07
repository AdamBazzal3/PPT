using System.ComponentModel.DataAnnotations;

namespace PPT.Validation
{
    public class AttendanceDateAttribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string dateString = value.ToString();
                DateTime parsedDate;

                if (!DateTime.TryParse(dateString, out parsedDate))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
