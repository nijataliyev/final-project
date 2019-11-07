using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class Department
    {
        public Department()
        {
            Shops = new HashSet<Shop>();
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }  
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        
    }
}
