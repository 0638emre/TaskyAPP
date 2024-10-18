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
{    
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

        public async Task<KonuKategoriResponseDTO> KonuKategoriGetirIdyeGore(int kategoriId)
        {

            var konukategorikontrol = await _dbContext.Kategoriler.Where(k => k.Id.Equals(kategoriId)).FirstOrDefaultAsync();

            if (konukategorikontrol is null)
            {
                throw new ApplicationException(BussinessConstans.KategoriBulunamadi);
            }
            
            var data = await _dbContext.KonuKategoriler
                .Include(k => k.Konu)
                .Include(k => k.Kategori)
                .Where(k => k.KategoriId.Equals(kategoriId)).ToListAsync();
            
            KonuKategoriResponseDTO konuKategoriResponseDto = new();
            konuKategoriResponseDto.KategoriId = konukategorikontrol.Id;
            konuKategoriResponseDto.KategoriAdi =konukategorikontrol.KategoriAdi;

            List<KonuKategoriKonularResponseDTO> konuKategoriKonularResponseDto = new();
            foreach (var k in data)
            {
                KonuKategoriKonularResponseDTO konu = new();
                konu.KonuId = k.KonuId;
                konu.KonuAdi = k.Konu.KonuAdi;
                
                konuKategoriKonularResponseDto.Add(konu);
            }

            konuKategoriResponseDto.KonuListesi = konuKategoriKonularResponseDto;
            

            return konuKategoriResponseDto;
        }

        public async Task<List<KonularinKategorileriResponseDTO>> KonuKategoriListesi()
        {
            var datas = await _dbContext.KonuKategoriler
                .Include(k => k.Konu)
                .Include(k => k.Kategori)
                .OrderBy(k => k.KonuId).ToListAsync();

            List<KonularinKategorileriResponseDTO> kategoriKonuListele = new();

          
            foreach (var data in datas)
            {
                KonularinKategorileriResponseDTO konuKatergoriGetirResponseDTO = new();
                konuKatergoriGetirResponseDTO.KategoriId = data.KategoriId;
                konuKatergoriGetirResponseDTO.KategoriAdi = data.Kategori.KategoriAdi;
                konuKatergoriGetirResponseDTO.KonuId = data.KonuId;
                konuKatergoriGetirResponseDTO.KonuAdi = data.Konu.KonuAdi;
     
                kategoriKonuListele.Add(konuKatergoriGetirResponseDTO);
            }
           
            return kategoriKonuListele;
        }

        //public async Task<List<KonularinKategorileriResponseDTO>> KonuKategoriListesi()
        //{
        //    var datas = await _dbContext.KonuKategoriler
        //                .Include(k => k.Konu)
        //                .Include(k => k.Kategori)
        //                .OrderBy(k => k.KonuId).ToListAsync();


        //    List<KonularinKategorileriResponseDTO> kategoriKonuListele = new();

        //    foreach (var data in datas)
        //    {
        //        KonularinKategorileriResponseDTO konuKatergoriGetirResponseDTO = new();
        //        konuKatergoriGetirResponseDTO.KategoriId = data.KategoriId; 
        //        konuKatergoriGetirResponseDTO.KategoriAdi = data.Kategori.KategoriAdi;
        //    }
        //    return null;
    }
} 

