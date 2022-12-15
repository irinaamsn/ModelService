using System;
using System.Collections.Generic;
using static ImitModelBl.Model.Category;
using static ImitModelBl.Model.EnumPlaceSevices;
using static ImitModelBl.Model.Level;

namespace ImitModelBl.Model
{
    public class Master
    {
        public int MasterId { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; } 
        public string Qualification { get; set; }
        public int IdPlaceService { get; set; }
        //public int ServiceId { get; set; }
        // public virtual ICollection<Sell> Sells { get; set; }
    }
}
