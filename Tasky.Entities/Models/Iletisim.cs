using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Entities.Models
{
    public class Iletisim
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public string EvAdres { get; set; }
        public string IsAdres { get; set; }
        public int PostaKodu { get; set; }
        public string KanGrubu { get; set; }
        public string Il { get;set; }
        public string Ilce { get; set; }
        public string Memleket { get; set; }
        public string AracPlaka { get; set; }

    }
}
