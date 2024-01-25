using System.ComponentModel.DataAnnotations;

namespace SAWBank.API.Validators
{
    public class BirthDateAttribute : ValidationAttribute
    {
        public string MinDate { get;}

        public BirthDateAttribute(string minDate)
        {
            MinDate = minDate;
        }

        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return true;
            }
            if (value is DateTime date)
            {
                ErrorMessage = "vous etes trop jeunes";
                return date >= DateTime.Parse(MinDate);
            }
            ErrorMessage = "La date est invalide";
            return false;
        }
    }
}
