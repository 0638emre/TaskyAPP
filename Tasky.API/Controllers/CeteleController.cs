using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CeteleController : ControllerBase
{
    private readonly IKullaniciKonuService _kullaniciKonuService;
    
    public CeteleController(IKullaniciKonuService kullaniciKonuService)
    {
        _kullaniciKonuService = kullaniciKonuService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> BugunTamamladim(int kullaniciId, int konuId)
    {
        var result = await _kullaniciKonuService.BugunTamamladim(kullaniciId, konuId);
        
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> CeteleGetirKullaniciIdyeGore(int kullaniciId)
    {
        var result = await _kullaniciKonuService.CeteleGetirKullaniciIdyeGore(kullaniciId);
        
        return Ok(result);
    } 
    
    [HttpGet("[action]")]
    public async Task<IActionResult> CeteleGetirIdyeGore(int ceteleId)
    {
        var result = await _kullaniciKonuService.CeteleGetirIdyeGore(ceteleId);
        
        return Ok(result);
    }   
    
    [HttpDelete("[action]")]
    public async Task<IActionResult> CeteleSil(int ceteleId)
    {
        var result = await _kullaniciKonuService.CeteleSil(ceteleId);
        
        return Ok(result);
    }  
    
    [HttpGet("[action]")]
    public async Task<IActionResult> CeteleListesi()
    {
        var result = await _kullaniciKonuService.CeteleListesi();
        
        return Ok(result);
    }
    
}