using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction
{
   public interface IIletisimService
    {
        Task<bool> IletisimBilgiEkle(IletisimEkleRequestDTO iletisimEkleRequest);
        Task<bool> IletisimBilgiSil(int Id);
        Task<bool> IletisimBilgiGuncelle(IletisimGuncelleRequestDTO iletisimGuncelleRequest);
        Task<List<IletisimResponseDTO>> IletisimBilgiListele();
    }
}
