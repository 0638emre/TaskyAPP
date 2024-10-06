using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class YetkiController : ControllerBase
    {
    private readonly IYetkiService _yetkiService;
    public YetkiController(IYetkiService yetkiService)
    {
        _yetkiService = yetkiService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> YetkiEkle(string yetkiAdi)
    {
        var result = await _yetkiService.YetkiEkle(yetkiAdi);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> YetkiGetirIdyeGore(int yetkiId)
    {
        var result = await _yetkiService.YetkiGetirIdyeGore(yetkiId);

        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> YetkiGuncelle(int yetkiId, string yetkiAdi)
    {
        var result = await _yetkiService.YetkiGuncelle(yetkiId, yetkiAdi);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> YetkileriListele()
    {
        var result = await _yetkiService.YetkileriListele();

        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> YetkiSil(int yetkiId)
    {
        var result = await _yetkiService.YetkiSil(yetkiId);

        return Ok(result);
    }
}

