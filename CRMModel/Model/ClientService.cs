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
        public Master Master { get; set; }//мастер который обслуживает
        public Queue<ListServices> Queue { get; set; }//очередь из пакета услуг каждого клиента (очередь клиентов)
        public Queue<Service> QueueServices { get; set; } = new Queue<Service>();
        public int TimeWorkingPlace { get; set; }
        //public bool IsExit { get; set; }=false; 
        public int ExitCustomer { get; set; }//не дождались в очереди
        public int CustomerReadyCount { get; set; }//кол-во готовых клиентов, чек закрыт?
        public int Count => QueueServices.Count;//кол-во
        public List<Customer> ListCustomerReady { get; set; } = new List<Customer>();
        public int TimeWashingHair { get; set; } = 20;
        public int TimeHairDrying { get; set; } = 15;
        public List<ListServices> ListServices { get; set; }= new List<ListServices>();

        public event EventHandler<Check> CheckClosed;//событие того что клиент обслужился
        //AutoResetEvent e v = new AutoResetEvent(false);

        public ClientService(int number,Master master)//TODO// MasterId
        {
            NumberPlaceOfService = number;
            Master = master;
            Queue = new Queue<ListServices>();//СПИСОК СВОИХ КЛИЕНТОВ
            //TimeWorkingPlace = Queue.FirstOrDefault().SumTime;
        }
        //public async void WorkingMaster(Service service, Customer customer)
        //{
        //    customer.IsCustomerReady = false;
        //    var servicesQueue = new Queue<Service>();
        //    servicesQueue.Enqueue(service);
        //    var customerTime = customer.TimeWait;
        //    var timeService = service.TimeRunning;
        //    await Task.Run(() => WaitingCustomer(customer));
        //}
        public async void WaitingCustomer(Customer customer)//метод ожидания клиента своей услуги
        {
            //Queue.Enqueue()
       


            var ts = TimeSpan.FromMilliseconds(customer.TimeWait * 10);
            
            await Task.Delay(ts);
            //if (t.Wait(ts))
            {
                if (!customer.IsCustomerReady)
                {
                    var exitCustomer = Queue.Dequeue();//
                    customer.IsCustomerReady = false;
                    Queue.Dequeue();    
                    ExitCustomer++;
                    foreach(Service service in exitCustomer)
                    {
                        if (QueueServices.Dequeue().ServiceId==service.ServiceId)
                           QueueServices.Dequeue();

                    }
                }
            }
            
        } 
        //public List<Service>
        public void EnqueueService(ListServices listServices,Service service)
        {

            QueueServices.Enqueue(service);
           // ListServices.Add(service);
        }
        public async void WaitingClientService(Service service, string namePlace)
        {
            
            if (QueueServices.Count >0)
            {
                int timeService = service.TimeRunning;//TODO
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 1) timeService = TimeHairDrying;
                if ((int)Enum.Parse(typeof(PlaceServices), namePlace) == 2) timeService = TimeWashingHair;
                var ts = TimeSpan.FromMilliseconds(timeService * 10);
                
                await Task.Delay(ts);
                QueueServices.Dequeue();//убираем из очереди услугу
            }
            
        }
        public void Enqueue(ListServices listServices)
        {
            //if (Queue.Count < MaxQueueLenght)//TODO//change on while - TimeWait

            Queue.Enqueue(listServices); //ставим в очередь клиента

            WaitingCustomer(listServices.Customer);
            //Timer timer = new Timer();
            //timer.Interval = customerTime * 100;
            //timer.Elapsed += OnTimedEvent;
            //timer.Enabled = true;

            //var TTimer = new Timer(
            //    new TimerCallback(TickTimer),
            //    null,
            //    1000,
            //    TimeWorkingPlace);
        }


        //private void TickTimer(object state)
        //{
        //    AutoResetEvent autoEvent = (AutoResetEvent)state;

        //    //if (!listServices.Customer.IsCustomerReady)
        //    //{
        //    //    ExitCustomer++;
        //    //   var customerExit =  Queue.Dequeue();
        //    //}
        //    //return new TimerCallback(TickTimer(new ListServi);
        //}

        //private void TickTimer(object state, ListServices list)
        //{
           
        //}
        //private void OnTimedEvent(object sender, ElapsedEventArgs e)
        //{
        //    ExitCustomer++;
        //}

        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }
            
            var listMasters = new List<Master>();
            listMasters.Add(Master);

           // ListServices list = null;
            //delete from queue customer
            var list = Queue.Dequeue();
            
            if (list != null)
            {
                list = Queue.Dequeue();
                // var t = list.SumTime;
                foreach (Service item in list)
                {
                    item.PlaceServiceType.ForEach(p => WaitingClientService(item,p));
                }

                list.Customer.IsCustomerReady = true;
                    ListCustomerReady.Add(list.Customer);
                    CustomerReadyCount++;
                    var check = new Check()
                    {   //Master = Master,
                        CheckId = list.Customer.CustomerId,
                        Masters = listMasters,//???????/
                        CustomerId = list.Customer.CustomerId,
                        Customer = list.Customer
                    };

                    var sells = new List<Sell>();//список услуг клиента

                    foreach (Service service in list)
                    {
                        var sell = new Sell()
                        {

                            Check = check,
                            ServiceId = service.ServiceId,
                            Service = service,
                            MasterId = Master.MasterId,
                            Master = Master
                        };

                        sells.Add(sell);
                        sum += service.Price;//сумма за все оказанные услуги
                    }

                    check.Price = sum;//итоговая сумма на выход

                    var result = $"Check: CustomerId {check.CustomerId}, sum {sum}\n";

                    CheckClosed?.Invoke(this, check);//обслужился
                
            }
            return sum;
        }
       
    }
    
}
