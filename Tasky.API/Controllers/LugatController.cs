using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;


namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LugatController(ILugatService _lugatService) : ControllerBase
{
   [HttpPost("[action]")]
   public async Task<IActionResult> OzluSozOlustur(int kullaniciId, string ozluSoz)
   {
      var result = await _lugatService.OzluSozEkle(ozluSoz, kullaniciId);
      
      return Ok(result);
   }  
   
   [HttpPut("[action]")]
   public async Task<IActionResult> OzluSozGuncelle(int lugatId, string ozluSoz)
   {
      var result = await _lugatService.OzluSozGuncelle(lugatId, ozluSoz);
      
      return Ok(result);
   }
   
   [HttpDelete("[action]")]
   public async Task<IActionResult> OzluSozSil(int lugatId)
   {
      var result = await _lugatService.OzluSozSil(lugatId);
      
      return Ok(result);
   } 
   
   [HttpGet("[action]")]
   public async Task<IActionResult> OzluSozGetirKullaniciIdyeGore(int kullaniciId)
   {
      var result = await _lugatService.OzluSozGetir(kullaniciId);
      
      return Ok(result);
   }
   
   [HttpGet("[action]")]
   public async Task<IActionResult> OzluSozleriListele()
   {
      var result = await _lugatService.OzluSozleriListele();
         
      return Ok(result);
   }
  
}