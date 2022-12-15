using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static ImitModelBl.Model.EnumPlaceSevices;

namespace ImitModelBl.Model
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public List<string> PlaceServiceType { get; set; } =new List<string>();
        public decimal Price { get; set; }
        public List<Master> ListMasters { get; set; } 
        public int TimeRunning { get; set; }
     
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return ServiceId;
        }

        public override bool Equals(object obj)
        {
            if (obj is Service service)
            {
                return ServiceId.Equals(service.ServiceId);
            }

            return false;
        }
    }
}
