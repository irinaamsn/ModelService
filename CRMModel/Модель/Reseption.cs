using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class Reseption
    {
        public Queue<ListServices> Queue { get; set; }// (очередь клиентов)
        public int ExitCustomer { get; set; }//не дождались в очереди//static
        public int CustomerReadyCount { get; set; }//кол-во готовых клиентов, чек закрыт?//
        public int Count => Queue.Count;//кол-во
        public int TimeWait { get; set; }
        public Customer Customer { get; set; }
        public List<Customer> ListCustomerReady { get; set; } = new List<Customer>();//

        public event EventHandler<Check> CheckClosed;//событие того что клиент обслужился
        public Reseption()
        {
            Queue = new Queue<ListServices>();
        }
        public void Enqueue(ListServices listServices)
        {
            Queue.Enqueue(listServices); //ставим в очередь клиента
            WaitingCustomer(listServices);
        }

        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }

            //var listMasters = new List<Master>();
            //listMasters.Add(Master);

            // ListServices list = null;
            //delete from queue customer
            var list = Queue.Dequeue();

            if (list != null)
            {
                Customer.IsCustomerReady = true;
                ListCustomerReady.Add(Customer);
                CustomerReadyCount++;
                var check = new Check()
                {   //Master = Master,
                    CheckId = Customer.CustomerId,
                   // Masters = listMasters,//???????/
                    CustomerId = Customer.CustomerId,
                    Customer = Customer
                };

                var sells = new List<Sell>();//список услуг клиента

                foreach (Service service in list)
                {
                    var sell = new Sell()
                    {

                        Check = check,
                        ServiceId = service.ServiceId,
                        Service = service,
                        //MasterId = Master.MasterId,
                        //Master = Master
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
        public async void WaitingCustomer(ListServices listServices)//метод ожидания клиента своей услуги
        {
            var ts = TimeSpan.FromMilliseconds(listServices.Customer.TimeWait * 10);

            await Task.Delay(ts);
            //if (t.Wait(ts))
           // {
                if (!listServices.Customer.IsCustomerReady)
                {
                    // foreach(var cust in Queue)
                    //if (Queue.Contains(customer.ListServices)
                    Queue.Dequeue();
                    listServices.Customer.IsCustomerReady = false;
                    ExitCustomer++;
              
                }
           // }

        }


    }

}
