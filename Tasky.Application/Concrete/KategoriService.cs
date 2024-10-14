using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete
{
    public class KategoriService : IKategoriService
    {
        private readonly TaskDBContext _dbContext;

        public KategoriService(TaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> KategoriEkle(string kategoriAdi)
        {
            var kategori = await _dbContext.Kategoriler.Where(k=>k.KategoriAdi.Equals(kategoriAdi)).FirstOrDefaultAsync();

            if (kategori is not null) 
            {
                throw new Exception(BussinessConstans.KategoriZatenBulunmaktadır);
            }

           var result = await _dbContext.Kategoriler.AddAsync(new Kategori() 
           {
               KategoriAdi = kategoriAdi,

           });

            if (result is not null)
            {
                throw new Exception(BussinessConstans.KategoriEklenemedi);
            }

            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<KategoriResponseDTO> KategoriGetirIdyeGore(int kategoriId)
        {

            KategoriResponseDTO kategoriResponseDto = new KategoriResponseDTO();

            var kategori = await _dbContext.Kategoriler.Where(k => k.Id.Equals(kategoriId)).FirstOrDefaultAsync();

            if (kategori is null)
            {
                throw new Exception(BussinessConstans.KategoriBulunamadi);
            }

            kategoriResponseDto.KategoriId = kategori.Id;
            kategoriResponseDto.KategoriAdi = kategori.KategoriAdi;

            return kategoriResponseDto;

        }

        public async Task<bool> KategoriGuncelle(int kategoriId, string kategoriAdi)
        {
            var kategori = await _dbContext.Kategoriler.Where(k=>k.Id.Equals(kategoriId)).FirstOrDefaultAsync();

            if (kategori is null) 
            {
                throw new Exception(BussinessConstans.KategoriGuncellenemedi);
            }

            kategori.KategoriAdi = kategori.KategoriAdi;

             _dbContext.Update(kategori);

            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<KategoriResponseDTO>> KategoriListele()
        {
            List<KategoriResponseDTO> kategorileriListele = new List<KategoriResponseDTO>();

            var kategoriListesi = await _dbContext.Kategoriler.ToListAsync();

            if (kategoriListesi.Count < 1)
            {
                throw new Exception(BussinessConstans.KategoriBulunamadi);
            }

            foreach (var kk in kategoriListesi)
            {
                KategoriResponseDTO kategoriResponseDto = new KategoriResponseDTO();
                kategoriResponseDto.KategoriId = kk.Id;
                kategoriResponseDto.KategoriAdi = kk.KategoriAdi;

                kategorileriListele.Add(kategoriResponseDto);
            }

            return kategorileriListele;
        }

        public async Task<bool> KategoriSil(int kategoriId)
        {
            var kategori = await _dbContext.Kategoriler.Where(k=>k.Id.Equals(kategoriId)).FirstOrDefaultAsync();
           
            if (kategori == null) 
            {
                throw new Exception(BussinessConstans.KategoriSilinemedi);
            }

             _dbContext.Kategoriler.Remove(kategori);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
