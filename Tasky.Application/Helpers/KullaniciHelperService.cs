using Microsoft.EntityFrameworkCore;
using Tasky.Application.Constans;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Helpers;

//helper örnek için verildi. herhangi bir yerde kullanılmıyor. umarım bir gün kullanılır.
public class KullaniciHelperService
{
    private readonly TaskDBContext _dbContext;

    public KullaniciHelperService(TaskDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Kullanici> KullaniciKontrol(int kullaniciId)
    {
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            throw new Exception(BussinessConstans.KullaniciBulunamadi);
        }
        
        return kullanici;
    }
}