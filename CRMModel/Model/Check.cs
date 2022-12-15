using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class Check
    {
        public int CheckId { get; set; }
        //public TimeOnly ReadyTime { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }
        //public virtual ICollection<Sell> SellId { get; set; }
        //public int MasterId { get; set; }
        //public virtual Master Master { get; set; }
        //список мастеров???
        public List<Master> Masters { get; set; }//???/
    }
}
