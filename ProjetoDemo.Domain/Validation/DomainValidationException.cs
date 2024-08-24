using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Validation
{
    public class DomainValidationException:Exception
    {
        public DomainValidationException(string error):base(error) { }
        
        public static void When(bool hasErro,string error)
        {
            if(hasErro)
                throw new DomainValidationException(error);
        }
    }
}
