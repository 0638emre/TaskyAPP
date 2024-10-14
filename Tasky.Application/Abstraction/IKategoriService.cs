using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction
{
   public interface IKategoriService
    {
        Task<bool> KategoriEkle(string kategoriAdi);

        Task<bool> KategoriSil(int kategoriId);

        Task<bool> KategoriGuncelle(int kategoriId, string kategoriAdi);

        Task<List<KategoriResponseDTO>> KategoriListele();

        Task<KategoriResponseDTO> KategoriGetirIdyeGore(int kategoriId);
    }
}
