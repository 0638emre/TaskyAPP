using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Entities.Models
{
    public class Yetki
    {
        public int Id { get; set; }
        public string YetkiAdi { get; set; }
        public ICollection<KullaniciYetki> KullaniciYetkileri { get; set; }
    }
}
