using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ImitModelBl.Model.Category;
using static ImitModelBl.Model.EnumPlaceSevices;
using System.Timers;
using Timer = System.Threading.Timer;
using System.Collections;

namespace ImitModelBl.Model
{
    public class ComputerModel
    {
        Random rnd = new();
        Generator generator = new();
        bool isRunning = false;
        //public List<Service> Services { get; set; } = new List<Service>();
        // List<Check> Checks { get; set; } = new List<Check>();
        //public List<Sell> Sell { get; set; } = new List<Sell>();
        public Queue<Master> BelowMasters { get; set; } = new Queue<Master>();
        public Queue<Master> HairMasters { get; set; } = new Queue<Master>();
        public Queue<Master> ManMasters { get; set; } = new Queue<Master>();
        public Queue<Master> SpaMasters { get; set; } = new Queue<Master>();
        public Queue<Master> StyleMasters { get; set; } = new Queue<Master>();
       // public List<ListServices> ListServices { get; set; } = new List<ListServices>();//1 cust(all list of services) = 1 master
        public List<ClientService> ClientServices { get; set; } = new List<ClientService>();
        public int CountWashingHair { get; set; } = 2;
        public int CountHairDrying { get; set; } = 1;
        public int CountHairChair { get; set; } = 3;
        public int CountStylingChair { get; set; } = 3;
        public int CountСhairSpa { get; set; } = 2;
        public int CountManHairChair { get; set; } = 2;
        
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        
        public ComputerModel()
        {
            var freeMasters = generator.GeneratorMasters(3,2,2,3,3);//TODO//WinForm
             generator.GeneratorServices();//TODO
            //var customers = generator.GeneratorNewCustomers(13);//TODO???????
           
            foreach (var master in freeMasters.Where(m=> m.Speciality== CategoryMaster.Hairdresser.ToString()))
            {
                HairMasters.Enqueue(master);
            }
            foreach (var master in freeMasters.Where(m => m.Speciality == CategoryMaster.ManMaster.ToString()))
            {
                ManMasters.Enqueue(master);
                
            }
            foreach (var master in freeMasters.Where(m => m.Speciality == CategoryMaster.SpaMaster.ToString()))
            {
                SpaMasters.Enqueue(master);
              
            }
            foreach (var master in freeMasters.Where(m => m.Speciality == CategoryMaster.Stylist.ToString()))
            {
                StyleMasters.Enqueue(master);
               
            }
            foreach (var master in freeMasters.Where(m => m.Speciality == CategoryMaster.BelowHairdresser.ToString()))
            {
                BelowMasters.Enqueue(master);

            }
            //foreach(var master in freeMasters)
            //{
            //    Masters.Enqueue(master);
            //}

            for (int i = 0; i < CountHairChair; i++)////кол-во мест обслуживания TODO//WinForm
            {
                ClientServices.Add(new ClientService((int)PlaceServices.HairDressingChair, HairMasters.Dequeue()));
                
                // ClientServices.Add(new ClientService((int)PlaceServices.HairDressingChair, ManMasters.Dequeue()));
            }
            for (int i = 0; i < CountHairDrying; i++)////кол-во мест обслуживания//TODO//WinForm
            {
                ClientServices.Add(new ClientService((int)PlaceServices.HairDrying, BelowMasters.Dequeue() ));
            }
            for (int i = 0; i < CountWashingHair; i++)////кол-во мест обслуживания
            {
                ClientServices.Add(new ClientService((int)PlaceServices.WashingHair, BelowMasters.Dequeue()));
            }
            for (int i = 0; i < CountСhairSpa; i++)
            {
                ClientServices.Add(new ClientService((int)PlaceServices.СhairForSpaTreatments, SpaMasters.Dequeue()));
            }
            for (int i = 0; i < CountStylingChair; i++)
            {
                ClientServices.Add(new ClientService((int)PlaceServices.HairStylingChair, StyleMasters.Dequeue()));
            }
            for (int i = 0; i < CountManHairChair; i++)
            {
                ClientServices.Add(new ClientService((int)PlaceServices.ManHairDressingChair, ManMasters.Dequeue()));
            }
            //for (int i= 0; i < 5; i++)////кол-во мест обслуживания= 5 услуг - TODO//WinForm
            //{
            //    ClientServices.Add(new ClientService(ClientServices.Count,Masters.Dequeue()));
            //}
            

        }

        public void Start()//TODO//async
        {
            isRunning = true;

            //var time = ClientServices.FirstOrDefault(X=>X.NumberPlaceOfService==ClientServices.Count).Queue.First(x => x == ListServices.Select(x => x.SumTime)).SumTime;
            var taskCustomers =  Task.Run(() => CreateListServices(15));//TODO
           // Thread.Sleep(5000);                                                          // taskCustomers.Wait();
            autoEvent.WaitOne();
           var clientServiceTask = ClientServices.Select(c => new Task(() =>  CashClientService(c)));

            foreach(var task in clientServiceTask)
            {
                task.Start();
            }
        }
        public void Stop()
        {
            isRunning= false;   
        }
       
        public int Waiting = 0;
        void CashClientService(ClientService clientService)//TODO// int TimeRunning
        {
            while(isRunning)
            {
               if (clientService.Count > 0)//TODO//кол-во обслуживающих мест//если очередь не пустпя то вызываем клиента из очереди
                {
                    // int t = clientService.TimeWorkingPlace;//TODO

                    // var ts = TimeSpan.FromMilliseconds(t * 10);

                    //await Task.Run(() =>
                    // {
                    //     Thread.Sleep(t *10);//время обслуживания
                    // });
                    // await task2;
                    //if (task2.Wait(ts))
                    //{

                    //var service = clientService.QueueServices.Dequeue();
                    //foreach (var pl in service.PlaceServiceType)
                    //{
                    //    //поиск кресла номер которого равен номеру места услуги которая выполняется 
                    //   var place = ClientServices.Find(c => c.NumberPlaceOfService == (int)Enum.Parse(typeof(PlaceServices), pl));
                    //    place.WaitingClientService(service, pl);
                    //    // cl.WaitingClientService(service);//ставим услугу в ожидание
                    //}
                     clientService.Dequeue();
                    //}
                    //var t = list.SumTime;

                    //var ts = TimeSpan.FromMilliseconds(t*10);

                    //Task task = Task.Run(() => 
                    //    Thread.Sleep(t * 10));//время обслуживания


                    //var TTimer = new Timer( new TimerCallback(TickTimer(clientService)),                     
                    //    null,
                    //    50,
                    //    Waiting);
                    // autoEvent.WaitOne();

                }
            }
        }

        private TimerCallback TickTimer(ClientService clientService)
        {
            clientService.Dequeue();
           // autoEvent.Set();
            return new TimerCallback(TickTimer(clientService));
        }

        private void TickTimer(object state, ClientService clientService)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)state;

            //if (Waiting)
        }

        void CreateListServices(int countCustomers)//create customers//нормaльное распр
        {
           while (isRunning)
            {
                var customers = generator.GeneratorNewCustomers(countCustomers);
                foreach (var customer in customers)
                {
                    //var newQueue = new Queue<Service>();
                    ClientService cl = null;
                    var listPlaces = new List<int>();
                    //ClientService cash = null;
                    var listService = new ListServices(customer);
                    foreach (var service in generator.GetRandomServices(1, 3))
                    {
                        listService.Add(service);
                        foreach (var pl in service.PlaceServiceType)
                        {
                            //поиск кресла номер которого равен номеру места услуги которая выполняется 
                            var  clArr = ClientServices.FindAll(c => c.NumberPlaceOfService == (int)Enum.Parse(typeof(PlaceServices), pl)).ToArray();
                            var minCount = clArr.Min(x=>x.Count);
                            cl = clArr.FirstOrDefault(x => x.Count == minCount);
                            cl.EnqueueService(listService,service);
                            //Task.Run(() => CashClientService(c)
                            listPlaces.Add(cl.NumberPlaceOfService);
                           
                           // cl.WaitingCustomer(customer);//ставим услугу в ожидание
                            //cash = ClientServices.
                        }

                        //cl.Enqueue(listService);//ставим клиента полностью в ожилание пока мастера не начнут обслуживать его пакет услуг

                    }

                    foreach (var pl in listPlaces)
                    {
                        //поиск кресла номер которого равен номеру места услуги которая выполняется 
                        // cl = ClientServices.Find(c => c.NumberPlaceOfService == (int)Enum.Parse(typeof(PlaceServices), pl));
                        cl = ClientServices.Find(x => x.NumberPlaceOfService == pl);
                        cl.Enqueue(listService);

                       // cl.WaitingCustomer(customer);//ставим услугу в ожидание
                                                     //cash = ClientServices.
                    }
                    // var cash = ClientServices.FirstOrDefault(cl=>cl.NumberPlaceOfService==);//choose master random//TODO
                    //cash.TimeWorkingPlace = listService.SumTime; 
                    //cash.Enqueue(listService);

                }
               autoEvent.Set();
               Thread.Sleep(2000);//TODO//time generator new customers
            }
          //TODO!!! выполняется обслуживается одно клиетнат(его пакета усулг) async и await параллельно с ругими клиентамит (без async/await) 
           
        }
    }
}
