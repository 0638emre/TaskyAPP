﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction
{
    public interface IKonuKategoriService
    {
        Task<bool> KategoriyeKonuEkle(int kategoriId, int konuId );

        Task<KonuKategoriResponseDTO> KonuKategoriGetirIdyeGore(int kategoriId);

        Task<bool> KategoriKonuSil(int kategoriId);

        Task<List<KonularinKategorileriResponseDTO>> KonuKategoriListesi();


    }
}
