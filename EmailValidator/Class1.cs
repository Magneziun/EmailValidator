using System.Text.RegularExpressions;

namespace EmailValidator
{
    public static class EmailValidator
    {
        public static ValidationResult ValidateEmail(string email)
        {
            // валидации с помощью регулярного выражения я так делал в экзамене по WPF и стырил оттуда
            bool isValid = Regex.IsMatch(email?.ToLower() ?? "",
                @"^(?=.{1,64}@)(?=.{1,255}$)(?!\.)(?!.*\.\.)[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z]{2,}$");

            return new ValidationResult(
                isValid,
                isValid ? "Email валиден" : "Некорректный email"
            );
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; }
        public string Message { get; }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}