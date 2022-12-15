using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ImitModelBl.Model.EnumPlaceSevices;

namespace ImitModelBl.Model
{
    public class CycleService
    {
        public Reseption Reseption { get; set; }
        public Service Service { get; set; }
        public Customer Customer { get; set; }
        public List<ClientService> ClientServices { get; set; } = new List<ClientService>();
        public int CountServices => QueueCycleServices.Count;//кол-во
        public Queue<Service> QueueCycleServices { get; set; } = new Queue<Service>();
        public CycleService(Customer customer, Service service, List<ClientService> clientServices)
        {
            Customer = customer;
            Service = service;
            ClientServices = clientServices;
        }
        public void EnqueueServiceCycle()//
        {
            QueueCycleServices.Enqueue(Service);
            foreach (var chair in Service.ChairsService)
            {
                //поиск кресла номер которого равен номеру места услуги которая выполняется 
                var clArr = ClientServices.FindAll(c => c.NumberPlaceOfService == (int)Enum.Parse(typeof(PlaceServices), chair)).ToArray();
                var minCount = clArr.Min(x => x.CountServices);
                var cl = clArr.FirstOrDefault(x => x.CountServices == minCount);//choose chair
                cl.EnqueueService(Service);
                //Task.Run(() => CashClientService(c)
            }
        }
        public void DequeueServiceCycle()//
        {
            //foreach(var clientService in ClientServices)
            //{
            //    Task.Run(() => clientService.DequeueService(Service, Enum.ToObject(typeof(PlaceServices), clientService.NumberPlaceOfService).ToString()));
                
            //}

            var clientServiceTask =  ClientServices.Select(c => new Task(() => c.DequeueService(Service, Enum.ToObject(typeof(PlaceServices), c.NumberPlaceOfService).ToString())));
            foreach (var task in clientServiceTask)
            {
                task.Start();
                task.Wait();
            }
            QueueCycleServices.Dequeue();
            Reseption.Dequeue();
        }
    }
}
