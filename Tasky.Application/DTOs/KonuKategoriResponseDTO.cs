using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Application.DTOs
{
    public class KonuKategoriResponseDTO
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }

        public List<KonuKategoriKonularResponseDTO> KonuListesi { get; set; }

    }

    public class KonuKategoriKonularResponseDTO
    {
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }
    }

    public class KonularinKategorileriResponseDTO
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }
    }


}
