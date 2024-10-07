using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction
{
    public interface IKullaniciYetkiService
    {
        Task<bool> KullaniciyaYetkiVer(int kullaniciId, int yetkiId);

        Task<KullaniciYetkiGetirResponseDTO> YetkiGetirKullaniciIdyeGore(int kullaniciId);

        Task<List<KullaniciYetkiGetirResponseDTO>> KullanicilarinYetkiListesi();
        
    }
}
