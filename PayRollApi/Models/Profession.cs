using System.Collections.Generic;

namespace PayRollApi.Models
{
    public class Profession
    {
        public Profession()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}