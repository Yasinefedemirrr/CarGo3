﻿using CarGo.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarGo.WebUI.ViewComponents.CarDetailViewComponents
{
     public class _CarDetailCarDescriptionByCarIdComponentPartial : ViewComponent
     {
         private readonly IHttpClientFactory _httpClientFactory;
         public _CarDetailCarDescriptionByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
         {
             _httpClientFactory = httpClientFactory;
         }

         public async Task<IViewComponentResult> InvokeAsync(int id)
         {
             ViewBag.carid = id;
             var client = _httpClientFactory.CreateClient();
             var resposenMessage = await client.GetAsync($"http://localhost:7266/api/CarDescriptions?id=" + id);
             if (resposenMessage.IsSuccessStatusCode)
             {
                 var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                 var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);
                 return View(values);
             }
             return View();
         }
     }
}
