using System.ComponentModel.DataAnnotations;

namespace University.API.Validations
{
    public class StreetNrMaxValue : ValidationAttribute
    {
        private int _max;

        public StreetNrMaxValue(int max)
        {
            _max = max;
        }

        public override bool IsValid(object? value)
        {
            
            if (value is string input)
            {
                var num =  input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Last();
                return int.TryParse(num, out int result) && result <= _max;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The street number must be less than or equal to {_max}";
        }
    }
}
