using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application
{
    public class MessageProvider
    {
        public static string CityCreateSuccessMessage = "Başarılı";
        public static string CityCreateErrorMessage = "Başarısız";

        public static string CreateSuccessMessage = "Kaydetme başarılı";
        public static string CreateErrorMessage = "Kaydetme başarısız";

        public static string UpdateSuccessMessage = "Güncelleme işlemi başarılı";
        public static string UpdateErrorMessage = "Güncelleme işlemi gerçekleştirilemedi";

        public static string DeleteSuccessMessage = "Silme işlemi başarılı";
        public static string DeleteErrorMessage = "silme işlemi gerçekleştirilemedi";

        public static string GetCreateSuccessMessage<TEntity>()
        {
            return $"{typeof(TEntity).Name} kaydetme aşamasında bir hata meydana geldi";
        }
    }
}
