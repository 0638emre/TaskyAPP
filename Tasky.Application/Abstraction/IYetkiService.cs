using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction
{
    public interface IYetkiService
    {
        Task<bool> YetkiEkle(string yetkiAdi);

        Task<bool> YetkiSil(int yetkiId);

        Task<YetkiGetirResponseDTO> YetkiGetirIdyeGore(int yetkiId);

        Task<List<YetkiGetirResponseDTO>> YetkileriListele();

        Task<bool> YetkiGuncelle(int yetkiId, string yetkiAdi);


    }
}
