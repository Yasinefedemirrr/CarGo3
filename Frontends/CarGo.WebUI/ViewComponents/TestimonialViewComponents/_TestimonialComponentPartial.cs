﻿
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarGo.Dto.TestimonialDtos;

namespace UdemyCarBook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponantPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _TestimonialComponantPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7266/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
