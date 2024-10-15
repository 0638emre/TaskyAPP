using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete
{    // hata mesajları ve mesajlar düzeltilecek
    public class KonuKategoriService : IKonuKategoriService
    {
        private readonly TaskDBContext _dbContext;

        public KonuKategoriService (TaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> KategoriKonuSil(int kategoriId)
        {
            var konukategoriler = await _dbContext.KonuKategoriler.Where(k => k.Id.Equals(kategoriId)).FirstOrDefaultAsync();

            if (konukategoriler is null)
            {
                throw new ApplicationException(BussinessConstans.KategoriBulunamadi);
            }

            var result = _dbContext.KonuKategoriler.Remove(konukategoriler);

            if (result is null)
            {
                throw new ApplicationException(BussinessConstans.KonuKategoriSilinemedi);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> KategoriyeKonuEkle(int kategoriId, int konuId)
        {
            var konukategori = await _dbContext.Kategoriler.Where(k => k.Id.Equals(kategoriId)).AnyAsync();

            if (!konukategori)
            {
                throw new ApplicationException(BussinessConstans.KategoriBulunamadi);
            }

            var konukategorikontrol = await _dbContext.Konular.Where(k => k.Id.Equals(konuId)).AnyAsync();

            if (!konukategorikontrol)
            {
                throw new ApplicationException(BussinessConstans.KullaniciBulunamadi);
            }


            var result = await _dbContext.KonuKategoriler.AddAsync(new KonuKategori()
            {
                KonuId = konuId,
                KategoriId = kategoriId,
            });

            if (result is null)
            {
                throw new ApplicationException(BussinessConstans.KategoriEklenemedi);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<KategoriResponseDTO>> KonuKategoriGetirIdyeGore(int kategoriId)
        {

            var konukategorikontrol = await _dbContext.Kategoriler.Where(k => k.Id.Equals(kategoriId)).FirstOrDefaultAsync();

            if (konukategorikontrol is null)
            {
                throw new ApplicationException(BussinessConstans.KategoriBulunamadi);
            }

            List<KonuResponseDTO> konukategorilist = new();

            var data = await _dbContext.KonuKategoriler
                .Include(k => k.Konu)
                .Include(k => k.Kategori)
                .Where(k => k.KategoriId.Equals(kategoriId)).ToListAsync();

            foreach (var k in data)
            {
                KategoriResponseDTO kategoriResponseDTO = new();

                //kategoriResponseDTO.CeteleId = k.Id;
                //kategoriResponseDTO.KullaniciId = k.KullaniciId;
                //kategoriResponseDTO.KullaniciAdveSoyad = k.Kullanici.Ad + " " + k.Kullanici.Soyad;
                //kategoriResponseDTO.KonuId = k.KonuId;
                //kategoriResponseDTO.KonuAd = k.Konu.KonuAdi;
                //kategoriResponseDTO.KayitTarih = k.KayitTarihi;

                //ceteleGetirList.Add(ceteleGetirResponseDto);



            }

            return null;
        }

        public Task<List<KategoriResponseDTO>> KonuKategoriListesi()
        {
            throw new NotImplementedException();
        }

        Task<List<KonuKategoriResponseDTO>> IKonuKategoriService.KonuKategoriGetirIdyeGore(int kategoriId)
        {
            throw new NotImplementedException();
        }

        Task<List<KonuKategoriResponseDTO>> IKonuKategoriService.KonuKategoriListesi()
        {
            throw new NotImplementedException();
        }
    } 
}
