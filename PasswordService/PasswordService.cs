using System;
using System.Collections.Generic;

namespace Password.Services
{
    public class PasswordService
    {
		private readonly ICollection<IRule> _rules;
		public PasswordService(ICollection<IRule> rules)
		{
			_rules = rules;
		}

        public bool IsValid(string pwd)
        {
			var password = pwd ?? String.Empty;

			foreach (var rule in _rules)
			{
				if (!rule.Pass(password)) return false;
			}

			return true;
        }
    }
}