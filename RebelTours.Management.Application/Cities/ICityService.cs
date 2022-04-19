using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Cities
{
    #region Interface
    //Interface 
    //implementation yerine (kodlama) yerine yalnızca yapılacak işlerin adını
    //dönüş tipini ve parametresini içeren soyutlama yapılarıdır.
    //işin nasıl yapıldığını değil, hangi işin yapılacağını söylemektir.

    //Peki işi, (implementation) kim yapacak.
    //yazdığınız interface'i hangi sınıf implement ediyorsa işi/kodlamayı o yapacak.

    //public class CityService:ICityService 
    //yukarıda yazan kodlamadaki sentaks'a interface'ler özelinde miras almak değiil,
    //Interface'i impelement etmek(uyarlamak/kodlamak) denir. 
    #endregion
    public interface ICityService :IService<CityDTO>
    {
        #region MyRegion
        //Domain nesnesi yerine DTO(veri taşıma nesneleri) kullanacağız.

        //CityDTO GetById(int id);
        //IEnumerable<CityDTO> GetAll();
        //CommandResult Create(CityDTO city);
        //CommandResult Update(CityDTO city);
        //CommandResult Delete(CityDTO city);

        //IEnumerable<City> GetAll(); böylee kalsaydı sonuçta bu metot controller tarafından çağrılacak.
        // controller'daki GetAll() metodu bana city koleksiyon döndürürecek böyle bir durumda.
        // city sınıfı domain katmanında , domain'e sadece application ulaşması lazım.
        //controller'da metot çağrılınca presentation katmanı da domain'e erişti.
        //Domain nesnesi değilde kendi yazdığımız Dto kavramı tam da burda devreye giriyor.
        //Domain'i tamamen encapsule edip gizliyor.sadece application kullanabilecek.
        //dto'lar(domain nesnesi) application ile presentation arasındaki asansör görevini görecek. 
        #endregion
    }
}
