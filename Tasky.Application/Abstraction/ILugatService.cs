using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface ILugatService
{
    Task<bool> OzluSozEkle(string ozluSoz, int kullaniciId);
    Task<bool> OzluSozGuncelle(int lugatId, string ozluSoz);
    Task<bool> OzluSozSil(int lugatId);
    Task<OzluSozResponseDTO> OzluSozGetir(int kullaniciId);
    Task<List<OzluSozResponseDTO>> OzluSozleriListele();
}