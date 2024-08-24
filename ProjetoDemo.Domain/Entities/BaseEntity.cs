using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        DateTime CreatedDate { get; set; } = DateTime.Now;
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; } 
    }
}
