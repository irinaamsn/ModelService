using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class Sell//сделать 1 услугу 1 мастером 1 клиенту
    {
        //public int SellId { get; set; }
        public int CheckId { get; set; }
        public  Check Check { get; set; }
        public int ServiceId { get; set; }
        public  Service Service { get; set; }
        public int MasterId { get; set; }
        public  Master Master { get; set; }
    }
}
