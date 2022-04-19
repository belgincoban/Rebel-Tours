using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Cities
{
    //application da service sınıfları interfaceler ve dto nesneleri bulunacak

    //Üzerinde davranış(behaviour) olmayan, sadece veri barındıran sınıflara POCO denir.
    //DTO=>Data Transfer Object
    //verileri taşıdığım sınıflarda metot olmayacak.
    //Bir projede katmanlar arasında sadece ve sadece veri taşımak için kullanılan üzerinde 
    //davranış olmayan (metotlar) (yani poco cinsi) sınıflar.
    //bu proje özelinde DTO sınıflarımız Presentation .. Application katmanları arasında veri taşıyacak.
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
