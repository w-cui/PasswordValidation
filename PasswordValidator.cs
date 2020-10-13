using System.Collections.Generic;
using System.Linq;

namespace PasswordValidation
{
    public class PasswordValidator
    {
        public readonly IEnumerable<IValidationRule> Rules;

        public PasswordValidator(IEnumerable<IValidationRule> rules)
        {
            this.Rules = rules;
        }

        public bool IsValid(string pwd)
        {
            return this.Rules.All(x => x.IsValid(pwd));
        }
    }
}