using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class KullaniciController : ControllerBase
{
    private readonly IKullaniciService _kullaniciService;

    public KullaniciController(IKullaniciService kullaniciService)
    {
        _kullaniciService = kullaniciService;
    }
    
    [HttpPost("KullaniciEkle")]
    public async Task<IActionResult> KullaniciEkle(KullaniciOlusturRequestDTO request)
    {
        var result =  await _kullaniciService.KullaniciOlustur(request);
        return Ok(result);
    }

    [HttpGet("KullaniciGetirIdyeGore")]
    public async Task<IActionResult> KullaniciGetirIdyeGore(int kullaniciId)
    {
        var result = await _kullaniciService.KullaniciGetirIdyeGore(kullaniciId);
        return Ok(result);
    }
    
    [HttpGet("KullanicilariListele")]
    public async Task<IActionResult> KullanicilariListele()
    {
        var result = await _kullaniciService.KullanicilariListele();
        return Ok(result);
    }

    [HttpDelete("KullaniciSil")]
    public async Task<IActionResult> KullaniciSil(int kullaniciId)
    {
        var result = await _kullaniciService.KullaniciSil(kullaniciId);
        return Ok(result);
    }

    [HttpPatch("KullaniciyiPasifeAl")]
    public async Task<IActionResult> KullaniciyiPasifeAl(int kullaniciId)
    {
        var result = await _kullaniciService.KullaniciyiPasifeAl(kullaniciId);
        return Ok(result);
    }
    
    [HttpPatch("KullaniciyiAktifEt")]
    public async Task<IActionResult> KullaniciyiAktifEt(int kullaniciId)
    {
        var result = await _kullaniciService.KullaniciyiAktifEt(kullaniciId);
        return Ok(result);
    }

    [HttpPut("KullaniciGuncelle")]
    public async Task<IActionResult> KullaniciGuncelle(KullaniciGuncelleRequestDTO request)
    {
        var response =  await _kullaniciService.KullaniciGuncelle(request);
        
        return Ok(response);
    }
}