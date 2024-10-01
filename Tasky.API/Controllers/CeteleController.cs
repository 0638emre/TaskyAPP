using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;

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
   
}