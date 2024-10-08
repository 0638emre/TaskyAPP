using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete
{
    public class IletisimService : IIletisimService
    {
        private readonly TaskDBContext _dbContext;

        public IletisimService(TaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> IletisimBilgiEkle(IletisimEkleRequestDTO iletisimEkleRequest)
        {
            var iletisim = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(iletisimEkleRequest.KullaniciId)).FirstOrDefaultAsync();

            if (iletisim is null) 
            {
                throw new Exception(BussinessConstans.KullaniciBulunamadi);
            }

            var result = await _dbContext.Iletisimler.AddAsync(new Iletisim()
            {
                  EvAdres= iletisimEkleRequest.EvAdres,
                  KullaniciId = iletisimEkleRequest.KullaniciId,
                  IsAdres = iletisimEkleRequest.IsAdres,
                  PostaKodu = iletisimEkleRequest.PostaKodu,
                  KanGrubu = iletisimEkleRequest.KanGrubu,
                  Il = iletisimEkleRequest.Il,
                  Ilce = iletisimEkleRequest.Ilce,
                  Memleket = iletisimEkleRequest.Memleket,
                  AracPlaka = iletisimEkleRequest.AracPlaka 
            });

            if (result is null)
            {
                throw new Exception(BussinessConstans.IletisimBilgileriBulunamadi);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<bool> IletisimBilgiGuncelle(IletisimGuncelleRequestDTO iletisimGuncelleRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<IletisimResponseDTO>> IletisimBilgiListele()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IletisimBilgiSil(int Id)
        {
            throw new NotImplementedException();
        }
    }
}