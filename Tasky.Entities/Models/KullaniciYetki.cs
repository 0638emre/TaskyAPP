using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Entities.Models
{
    public class KullaniciYetki
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }
        public DateTime KayitTarihi { get; set; }

    }
}
