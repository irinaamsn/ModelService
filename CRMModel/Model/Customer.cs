using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TimeWait { get; set; }
        public bool IsCustomerReady { get; set; }
        // public virtual ICollection<Check> Checks { get; set; }
        public List<Service> ListServices { get; set; } = new List<Service>();
        public override string ToString()
        {
            return $"{CustomerName} can wait {TimeWait}";
        }
    }
}
