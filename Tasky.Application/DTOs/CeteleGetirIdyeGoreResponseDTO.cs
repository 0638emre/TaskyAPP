using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Application.DTOs
{
    public class CeteleGetirIdyeGoreResponseDTO
    {
        public int CeteleId { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdveSoyad { get; set; }
        public int KonuId { get; set; }
        public string KonuAd { get; set; }
        public DateTime KayitTarih { get; set; }
    }
}
