using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Entities.Models
{
    public class KonuKategori
    {
        public int Id { get; set; }

        public Konu Konu { get; set; }

        public int KonuId { get; set; }

        public Kategori Kategori { get; set; }

    }
}
