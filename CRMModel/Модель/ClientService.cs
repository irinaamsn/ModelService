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
        public int NumberPlaceOfService { get; set; }//number
        public int ClientServiceID { get; set; }
       // public Reseption Reseption { get; set; }//???
       // public CycleService CycleService { get; set; }
        public Master Master { get; set; }//мастер который обслуживает
        public Queue<Service> QueueServices { get; set; }
        //public int TimeWorkingPlace { get; set; }//??
        public int CountServices => QueueServices.Count;//кол-во
        public int TimeWashingHair { get; set; } = 20;
        public int TimeHairDrying { get; set; } = 15;
       

        //public event EventHandler<Check> CheckClosed;//событие того что клиент обслужился
        //AutoResetEvent e v = new AutoResetEvent(false);

        public ClientService(int id,int number,Master master)
        {
            NumberPlaceOfService = number;
            Master = master;
            ClientServiceID= id;    
            QueueServices = new Queue<Service>();//СПИСОК услуг на очередь//////TODO
            
        }
        //public async void WaitingCustomer(Customer customer)//метод ожидания клиента своей услуги
        //{
        //    var ts = TimeSpan.FromMilliseconds(customer.TimeWait * 10);
            
        //    await Task.Delay(ts);
        //    //if (t.Wait(ts))
        //    {
        //        if (!customer.IsCustomerReady)
        //        {
        //            // foreach(var cust in Queue)
        //            //if (Queue.Contains(customer.ListServices)
        //            Queue.Dequeue();
        //            customer.IsCustomerReady = false;

        //           // Queue.Dequeue();    

        //            ExitCustomer++;
        //            //foreach(Service service in exitCustomer)
        //            //{
        //            //    //var serv = QueueServices.Where(x => x.ServiceId == service.ServiceId);
        //            //    QueueServices.Dequeue();
        //            //}
        //        }
        //    }
            
        //} 
        //public List<Service>
        public void EnqueueService(Service service)
        {
            QueueServices.Enqueue(service);//добавляем услугу в очередь к креслу
           // ListServices.Add(service);
        }
        public async void DequeueService(Service service, string namePlace)
        {
            if (QueueServices.Count >0)
            {
                int timeService = service.TimeRunning;//TODO
                
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 1) timeService = TimeHairDrying;
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 2) timeService = TimeWashingHair;
                var ts = TimeSpan.FromMilliseconds(timeService * 10);
                
                await Task.Delay(ts);//ждем когда на этом кресле закончится выполнятся предуслуга (одна из циклов услуги)
                QueueServices.Dequeue();//убираем из очереди услугу
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
