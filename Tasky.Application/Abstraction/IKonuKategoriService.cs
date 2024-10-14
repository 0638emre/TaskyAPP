using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Application.Abstraction
{
    public interface IKonuKategoriService
    {
        public Task<bool> KategoriyeKonuEkle(int kategoriId, int konuId );
    }
}
