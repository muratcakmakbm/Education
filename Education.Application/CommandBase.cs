using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Education.Application
{
    public abstract class CommandBase : IValidatableObject
    {
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}
