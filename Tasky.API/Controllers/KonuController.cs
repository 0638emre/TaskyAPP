using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class KonuController : ControllerBase
{
   
   private readonly IKonuService _konuService;
   public KonuController(IKonuService konuService)
   {
      _konuService = konuService;
   }
   
   [HttpPost("KonuEkle")]
   public async Task<IActionResult> KonuEkle(string konuAdi)
   {
      var result =  await _konuService.KonuEkle(konuAdi);
      
      return Ok(result);
   }
   
   [HttpPut("KonuGuncelle")]
   public async Task<IActionResult> KonuGuncelle(int konuId, string konuAdi)
   {
      var result =  await _konuService.KonuGuncelle(konuId, konuAdi);
      
      return Ok(result);
   }
   
   [HttpDelete("KonuSil")]
   public async Task<IActionResult> KonuSil(int konuId)
   {
      var result =  await _konuService.KonuSil(konuId);
      
      return Ok(result);
   }
   
   [HttpGet("KonuIdyeGoreGetir")]
   public async Task<IActionResult> KonuIdyeGoreGetir(int konuId)
   {
      var result =  await _konuService.KonuGetirIdyeGore(konuId);
      
      return Ok(result);
   }
   
   [HttpGet("KonulariListele")]
   public async Task<IActionResult> KonulariListele()
   {
      var result =  await _konuService.KonulariListele();
      
      return Ok(result);
   }
  
}