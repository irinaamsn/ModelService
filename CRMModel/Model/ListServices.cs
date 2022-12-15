using ImitModelBl.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class ListServices: IEnumerable//list services of customer
    {
        public Customer Customer { get; set; }
        public Master Master { get; set; }
        public List<Service> Services { get; set; }
        //public Master Master { get; set; }//TODO
        public decimal PriceAllServices => GetAll().Sum(p => p.Price);//sum all services from list
        public int SumTime => GetAll().Sum(p => p.TimeRunning);//delete
        public ListServices(Customer customer)
        {
            Customer = customer;
            Services = new List<Service>();
            //Master = master;    
        }

        public void Add(Service service)
        {
            Services.Add(service);
            Customer.ListServices.Add(service);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var service in Services)
            {
                yield return service;
            }
        }

        public List<Service> GetAll()
        {
            var result = new List<Service>();
            foreach (Service i in this)
            {
                result.Add(i);
                
            }
           
            return result;
        }
    }
}
