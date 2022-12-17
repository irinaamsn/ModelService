using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ImitModelBl.Model.EnumPlaceSevices;
//using System.Timers;

namespace ImitModelBl.Model
{
    public class ClientService//обслуживание клиента
    {
        public Reseption Reseption { get; set; } = new Reseption();
        public int NumberPlaceOfService { get; set; }//number
        public int ClientServiceID { get; set; }
       // public List<CycleService> CycleServices { get; set; }
        public Master Master { get; set; }//мастер который обслуживает
        public Queue<Service> QueueServices { get; set; }
        //public int TimeWorkingPlace { get; set; }//??
        public int CountServices => QueueServices.Count;//кол-во
        public int TimeWashingHair { get; set; } = 20;
        public int TimeHairDrying { get; set; } = 15;
        public List<Customer> Customers { get; set; }
        

        //public event EventHandler<Check> CheckClosed;//событие того что клиент обслужился
        //AutoResetEvent e v = new AutoResetEvent(false);

        public ClientService(int id,int number,Master master)
        {
            NumberPlaceOfService = number;
            Master = master;
            ClientServiceID= id;    
            QueueServices = new Queue<Service>();//СПИСОК услуг на очередь////// 
            Customers= new List<Customer>();
        }

        public void EnqueueService(Service service, Customer customer)
        {
            QueueServices.Enqueue(service);//добавляем услугу в очередь к креслу
            if (!Customers.Contains(customer)) Customers.Add(customer);
           
        }
        public void DequeueService(Customer customer)//связать 2 метода
        {
            if (customer.StatusWait == false)
            {
                for (int i = 0; i < customer.ListServices.GetAll().Count; i++)
                {
                    var service = QueueServices.Dequeue();//убираем из очереди услугу  
                    Customers.Remove(customer);
                }
            }
            else
            {
                var service = QueueServices.Dequeue();//убираем из очереди услугу   
                var list = Customers.Find(ls => ls == customer).ListServices.Services;

                WaitingService(customer, list, service, Enum.ToObject(typeof(PlaceServices), NumberPlaceOfService).ToString());

            }
        }
        public void WaitingService(Customer customer,List<Service> list,Service service, string namePlace)
        {
            if (QueueServices.Count > 0)
            {
                int timeService = service.TimeRunning;//TODO
                
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 1) timeService = TimeHairDrying;
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 2) timeService = TimeWashingHair;
                var ts = TimeSpan.FromMilliseconds(timeService * 10);
                
                 Task.Delay(ts).Wait();//ждем когда на этом кресле закончится выполнятся предуслуга (одна из циклов услуги)
                //QueueServices.Dequeue();
                list.Remove(service);
            }
            if (list.Count == 0)
            {
                customer.IsCustomerReady = true;
                Customers.Remove(customer);
                Reseption.Dequeue(customer);
            }
            
        }
        //public void Enqueue(ListServices listServices)
        //{
        //    if (Queue.Count < MaxQueueLenght)//TODO//change on while - TimeWait

        //        Queue.Enqueue(listServices); //ставим в очередь клиента

        //    WaitingCustomer(listServices.Customer);//ожилает
        //    Timer timer = new Timer();
        //    timer.Interval = customerTime * 100;
        //    timer.Elapsed += OnTimedEvent;
        //    timer.Enabled = true;

        //    var TTimer = new Timer(
        //        new TimerCallback(TickTimer),
        //        null,
        //        1000,
        //        TimeWorkingPlace);
        //}


        //public void Dequeue()
        //{
            
        //    if (Queue.Count == 0)
        //    {
                
        //    }
            
        //    var listMasters = new List<Master>();
        //    listMasters.Add(Master);

        //   // ListServices list = null;
        //    //delete from queue customer
          

        //    if (list != null)
        //    {
        //        // var t = list.SumTime;
        //        foreach (Service item in list)
        //        {
        //            item.PlaceServiceType.ForEach(p => 
        //            { 
        //                WaitingClientService(item, p); 

        //            });//TODO
        //        }
        //        //token//TODO
               
                
        //    }
          
        //}
       
    }
    
}
