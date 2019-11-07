using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class Shop
    {
        public Shop()
        {
            Workers = new HashSet<Worker>();
            Bonus = new HashSet<Bonus>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<Bonus> Bonus { get; set; }
    }
}
