

using ImitModelBl.Model;
using System;

namespace ImitModelBl
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new ComputerModel();
            model.Start();
            var cust = model.ClientServices;
            //foreach(var c in cust)
            //{
            //    Console.WriteLine(c.MasterId+"\n");
            //}
           // var c1= new Customer()
           // {
           //     CustomerName="1",
           //     CustomerId = 1
           // };

           // var c2= new Customer()
           // {
           //     CustomerName = "2",
           //     CustomerId = 2
           // };

           // var master1 = new Master()
           // {
           //     Name = "sTILIST",
           //     MasterId = 1
           // };
           // var master2 = new Master()
           // {
           //     Name = "TOPmASTER",
           //     MasterId = 2
           // };

           // var service1 = new Service()
           // {
           //     ServiceId = 1,
           //     Name="s1",
           //     Price = 100
                

           // };
           // var service2 = new Service()
           // {
           //     ServiceId = 2,
           //     Name = "s2",
           //     Price = 200
               
           // };

           // var cart1 = new ListServices(c1,master1);
           // cart1.Add(service1);
           // cart1.Add(service2);

           // var cart2 = new ListServices(c2,master2);
           // cart2.Add(service1);
           // cart2.Add(service2);
         

           // var clientService = new ClientService(cart1.Master.MasterId, cart1.Master);
           // //clientService.MaxQueueLenght = 10;
           // clientService.Enqueue(cart1);

           // var clientService2 = new ClientService(cart2.Master.MasterId, cart2.Master);
           // clientService2.Enqueue(cart2);

           //// var cart1ExpectedResult = 400;
           //// var cart2ExpectedResult = 500;

           // // act
           // var cart1ActualResult = clientService.Dequeue();
           // var cart2ActualResult = clientService2.Dequeue();

        
        }
    }
}
