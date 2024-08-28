using System.ComponentModel.DataAnnotations;
using University.API.Data;
using University.API.Models.Dtos;

namespace University.API.Validations
{
    public class ValidateLastName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // var context = validationContext.GetRequiredService<UniversityContext>();

            const string errorMessage = "Firstname cant be equal to Lastname";

            if (value is string input)
            {
                if(validationContext.ObjectInstance is StudentCreateDto dto)
                {
                    return dto.FirstName.Trim().Equals(input.Trim(), StringComparison.OrdinalIgnoreCase) ?
                        new ValidationResult(errorMessage) : 
                        ValidationResult.Success;
                }
            }

            return new ValidationResult("Something went wrong");


        }
    }
}
