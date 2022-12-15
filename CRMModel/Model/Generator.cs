using ImitModelBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ImitModelBl.Model.Category;
using static ImitModelBl.Model.Level;
using static ImitModelBl.Model.EnumServices;
using static ImitModelBl.Model.EnumPlaceSevices;

namespace ImitModelBl.Model
{
    public class Generator
    {
        Random rnd = new();
        public List<Customer> Customers { get; set; } = new List<Customer>();//существущие клиенты 
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Master> Masters { get; set; } = new List<Master>();
        public List<Customer>GeneratorNewCustomers(int count)//TODO//count - настройка???
        {
            var result = new List<Customer>();
            for (var i= 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,//TODO
                    CustomerName = Guid.NewGuid().ToString().Split('-').FirstOrDefault(),//TODO?
                    TimeWait = rnd.Next(1,60)
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }
        public List<Service> GeneratorServices()
        {
            var result = new List<Service>();

            //for (var i = 0; i < count; i++)
            
            var service1 = new Service()
            {
                ServiceId = 1,
                Name = AllServices.стрижка.ToString(),
                //Name = Enum.GetName(typeof(AllServices),rnd.Next(1,5)),//Guid.NewGuid().ToString().Substring(0, 5),
                PlaceServiceType = Enum.GetNames(typeof(PlaceServices)).Where(X => X != PlaceServices.HairStylingChair.ToString() && X != PlaceServices.СhairForSpaTreatments.ToString() && X != PlaceServices.ManHairDressingChair.ToString()).ToList(),
                //ListMasters = Masters.Where(m => m.Speciality == CategoryMaster.Hairdresser.ToString() && m.Speciality == CategoryMaster.ManMaster.ToString()).ToList(),
                Price = Convert.ToDecimal(rnd.Next(3000, 15000)),//individ
                TimeRunning = rnd.Next(60, 240),//individ
            };
            //var masters = Masters.FindAll(m => m.IdPlaceService ==(int)PlaceServices.HairDressingChair && m.IdPlaceService== (int)PlaceServices.ManHairDressingChair);
            Services.Add(service1);
            result.Add(service1);
            var service2 = new Service()
            {
                ServiceId = 2,
                Name = AllServices.бритье.ToString(),
                PlaceServiceType = Enum.GetNames(typeof(PlaceServices)).Where(X => X == PlaceServices.ManHairDressingChair.ToString()).ToList(),
                ListMasters = Masters.Where(m => m.Speciality == CategoryMaster.ManMaster.ToString()).ToList(),
                Price = Convert.ToDecimal(rnd.Next(1000, 5000)),
                TimeRunning = rnd.Next(20, 90),
            };
            Services.Add(service2);
            result.Add(service2);
            var service3 = new Service()
            {
                ServiceId = 3,
                Name = AllServices.покраска_волос.ToString(),
                PlaceServiceType = Enum.GetNames(typeof(PlaceServices)).Where(X => X != PlaceServices.HairStylingChair.ToString() && X != PlaceServices.СhairForSpaTreatments.ToString() && X != PlaceServices.ManHairDressingChair.ToString()).ToList(),
                //ListMasters = Masters.Where(m => m.Speciality == CategoryMaster.Hairdresser.ToString() && m.Speciality == CategoryMaster.ManMaster.ToString() && m.Speciality == CategoryMaster.Stylist.ToString()).ToList(),
                Price = Convert.ToDecimal(rnd.Next(5000, 30000)),//individ
                TimeRunning = rnd.Next(60, 360),//individ
            };
            Services.Add(service3);
            result.Add(service3);
            var service4 = new Service()
            {
                ServiceId = 4,
                Name = AllServices.укладка.ToString(),
                PlaceServiceType = Enum.GetNames(typeof(PlaceServices)).Where(X => X != PlaceServices.HairStylingChair.ToString() && X != PlaceServices.СhairForSpaTreatments.ToString() && X != PlaceServices.ManHairDressingChair.ToString()).ToList(),
                ListMasters = Masters.Where(m => m.Speciality == CategoryMaster.Hairdresser.ToString() && m.Speciality == CategoryMaster.ManMaster.ToString() && m.Speciality == CategoryMaster.Stylist.ToString()).ToList(),
                Price = Convert.ToDecimal(rnd.Next(5000, 25000)),//individ
                TimeRunning = rnd.Next(60, 180),//individ
            };
            Services.Add(service4);
            result.Add(service4);
            var service5 = new Service()
            {
                ServiceId = 5,
                Name = AllServices.уход_за_волосами.ToString(),
                PlaceServiceType = Enum.GetNames(typeof(PlaceServices)).Where(X => X != PlaceServices.HairStylingChair.ToString() && X != PlaceServices.СhairForSpaTreatments.ToString() && X != PlaceServices.ManHairDressingChair.ToString()).ToList(),
                ListMasters = Masters.Where(m => m.Speciality == CategoryMaster.SpaMaster.ToString()).ToList(),
                Price = Convert.ToDecimal(rnd.Next(3000, 15000)),//individ
                TimeRunning = rnd.Next(60, 120),//individ
            };
            Services.Add(service5);
            result.Add(service5); 
            
            return result;
        }
        public List<Service> GetRandomServices(int min, int max)
        {
            var result = new List<Service>();
            var count = rnd.Next(min, max);
            for (var i = 0; i < count; i++)
            {
                result.Add(Services[(rnd.Next(0,Services.Count-1))]);//рандомный пакет услуг 
            }
            return result;
        }
        public List<Master> GeneratorMasters(int countHair, int countMan, int countSpa, int countStyle, int countBelow)//TODO//counts - настройка
        {
            var result = new List<Master>();
            for (var i = 0; i < countHair; i++)
            {
                var master = new Master()
                {
                    MasterId = Masters.Count,
                    Name = Guid.NewGuid().ToString().Split('-').FirstOrDefault(),
                    Speciality = CategoryMaster.Hairdresser.ToString(),
                    Qualification = Enum.GetName(typeof(LevelMaster), rnd.Next(2, 4)),
                    IdPlaceService = (int)PlaceServices.HairDressingChair//
                };
                Masters.Add(master);
                result.Add(master);
               
            }
            for (var i = 0; i < countMan; i++)
            {
                var master = new Master()
                {
                    MasterId = Masters.Count,
                    Name = Guid.NewGuid().ToString().Split('-').ToString(),
                    Speciality = CategoryMaster.ManMaster.ToString(),
                    Qualification = Enum.GetName(typeof(LevelMaster), rnd.Next(2, 4)),
                    IdPlaceService = (int)PlaceServices.ManHairDressingChair//
                };
                Masters.Add(master);
                result.Add(master);
               
            }
            for (var i = 0; i < countSpa; i++)
            {
                var master = new Master()
                {
                    MasterId = Masters.Count,
                    Name = Guid.NewGuid().ToString().Split('-').ToString(),
                    Speciality = CategoryMaster.SpaMaster.ToString(),
                    Qualification = Enum.GetName(typeof(LevelMaster), rnd.Next(2, 4)),
                    IdPlaceService =(int) PlaceServices.СhairForSpaTreatments//
                };
                Masters.Add(master);
                result.Add(master);
               
            }
            for (var i = 0; i < countStyle; i++)
            {
                var master = new Master()
                {
                    MasterId = Masters.Count,
                    Name = Guid.NewGuid().ToString().Split('-').ToString(),
                    Speciality = CategoryMaster.Stylist.ToString(),
                    Qualification = Enum.GetName(typeof(LevelMaster), rnd.Next(2, 4)),
                    IdPlaceService = (int)PlaceServices.HairStylingChair//
                };
                Masters.Add(master);
                result.Add(master);
               
            }
            for (var i = 0; i < countBelow; i++)
            {
                var master = new Master()
                {
                    MasterId = Masters.Count,
                    Name = Guid.NewGuid().ToString().Split('-').ToString(),
                    Speciality = CategoryMaster.BelowHairdresser.ToString(),
                    Qualification = Enum.GetName(typeof(LevelMaster), 1),
                    IdPlaceService = (int)(PlaceServices.HairDrying | PlaceServices.WashingHair)//
                };
                Masters.Add(master);
                result.Add(master);

            }
            return result;
        }
    }
}
