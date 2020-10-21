using System;
using System.Text.RegularExpressions;

namespace Password.Services
{
    public class PasswordService
    {
		public PasswordService()
		{
		}

        public bool IsValid(string pwd)
        {
			var password = pwd ?? String.Empty;

			if (IsBlank(password)) return false;
			if (!LengthIsValid(password)) return false;
			if (!HasLetter(password)) return false;
			if (!HasDigit(password)) return false;
			if (!HasUppercaseLetter(password)) return false;
			if (!HasLowercaseLetter(password)) return false;
			if (HasIllegalCharacter(password)) return false;
			if (HasRepeatedCharacter(password)) return false;
			if (HasRepeatedSubstring(password)) return false;

			return true;
        }

		private bool IsBlank(string password)
		{
			return string.IsNullOrWhiteSpace(password);
		}

		private bool LengthIsValid(string password)
		{
			return password.Length>=6 && password.Length<=24;
		}

		private bool HasLetter(string password)
		{
			var regex = new Regex("[a-zA-Z]");
			return regex.IsMatch(password);
		}

		private bool HasDigit(string password)
		{
			var regex = new Regex("[0-9]");
			return regex.IsMatch(password);
		}

		private bool HasUppercaseLetter(string password)
		{
			var regex = new Regex("[A-Z]");
			return regex.IsMatch(password);
		}

		private bool HasLowercaseLetter(string password)
		{
			var regex = new Regex("[a-z]");
			return regex.IsMatch(password);
		}

		private bool HasIllegalCharacter(string password)
		{
			var regex = new Regex(@"[0-9a-zA-Z!@#$%^&*()+=_\-{}[\]:;""'?<>,.]");
			return regex.Matches(password).Count != password.Length;
		}

		private bool HasRepeatedCharacter(string password)
		{
			var regex = new Regex(@"(\w)\1\1");
			return regex.IsMatch(password);
		}
		
		private bool HasRepeatedSubstring(string password)
		{
			var regex = new Regex(@"^(.{2,})\1{1,}$");
			return regex.IsMatch(password);
		}
    }
}