using System;
using System.Text.RegularExpressions;

namespace Password.Services
{
	public interface IRule
	{
		bool Pass(string password);
	}

	public class Length: IRule
	{
		public bool Pass(string password)
		{
			return new Regex(".{6,24}").IsMatch(password);
		}
	}

	public class Alphabet: IRule
	{
		public bool Pass(string password)
		{
			return new Regex("[a-zA-Z]").IsMatch(password);
		}
	}

	public class Digit: IRule
	{
		public bool Pass(string password)
		{
			return new Regex("[0-9]").IsMatch(password);
		}
	}

	public class Uppercase: IRule
	{
		public bool Pass(string password)
		{
			return new Regex("[A-Z]").IsMatch(password);
		}
	}

	public class Lowercase: IRule
	{
		public bool Pass(string password)
		{
			return new Regex("[a-z]").IsMatch(password);
		}
	}

	public class LegalCharacter: IRule
	{
		/// "-" and "]" need to be escaped with "\", also double quote(") needs to be escaped with ".
		public bool Pass(string password)
		{
			var regex = new Regex(@"[0-9a-zA-Z!@#$%^&*()+=_\-{}[\]:;""'?<>,.]");
			return regex.Matches(password).Count == password.Length;
		}
	}

	public class RepeatedCharacter : IRule
	{
		/// "aa" is OK, "aaa" is NOT OK
		public bool Pass(string password)
		{
			return !(new Regex(@"(\w)\1\1").IsMatch(password));
		}
	}

	public class RepeatedSubstring : IRule
	{
		/// "abcabc" is NOT OK
		public bool Pass(string password)
		{
			return !(new Regex(@"^(.{2,})\1{1,}$").IsMatch(password));
		}
	}
}
