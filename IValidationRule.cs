using System.Text.RegularExpressions;

namespace PasswordValidation
{
    public interface IValidationRule
    {
        bool IsValid(string pwd);
    }

    public class ScopeRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return new Regex(@"[0-9a-zA-Z!@#$%^&*()+=_\-{}[\]:;""'?<>,.]").Matches(pwd).Count == pwd.Length;
        }
    }

    public class LengthRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return new Regex(".{6,24}").IsMatch(pwd);
        }
    }

    public class UppercaseRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return new Regex("[A-Z]").IsMatch(pwd);
        }
    }

    public class LowercaseRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return new Regex("[a-z]").IsMatch(pwd);
        }
    }

    public class DigitRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return new Regex("[0-9]").IsMatch(pwd);
        }
    }

    public class RepeatingCharRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return !(new Regex(@"(\w)\1\1").IsMatch(pwd));
        }
    }

    public class RepeatingSubstrRule: IValidationRule 
    {
        public bool IsValid(string pwd)
        {
            return !(new Regex(@"(.+)\1").IsMatch(pwd));
        }
    }
}