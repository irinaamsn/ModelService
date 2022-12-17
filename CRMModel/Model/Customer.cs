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
        public bool IsCustomerReady { get; set; } = false;
        public ListServices ListServices { get; set; } = new ListServices();
        public bool StatusWait { get; set; } = false;
        // public virtual ICollection<Check> Checks { get; set; }
        // public ListServices ListServices { get; set; }
        public override string ToString()
        {
            return $"{CustomerName} can wait {TimeWait}";
        }
    }
}

