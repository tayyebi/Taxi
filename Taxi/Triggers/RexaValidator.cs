using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Triggers
{
    class RexaValidator
    {
        public RexaValidator(object ModelInstance)
        {
            var validationContext = new ValidationContext(ModelInstance, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(ModelInstance, validationContext, results, true))
            {
                var t = new StringBuilder();

                foreach (var item in results)
                {
                    t.Append("\r\n- " + item.ErrorMessage);
                }
                throw new RexaException(t.ToString());
            }

        }
    }
}
