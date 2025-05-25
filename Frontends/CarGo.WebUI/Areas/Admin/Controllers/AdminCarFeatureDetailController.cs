using CarGo.Dto.CarFeatureDtos;
using CarGo.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarGo.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7266/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> _resultCarFeatureByCarIdDtos)
        {
            foreach (var item in _resultCarFeatureByCarIdDtos)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("http://localhost:7266/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("http://localhost:7266/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }


            }
            return RedirectToAction("Index", "AdminCar");
        }
        [Route("CreateFeatureByCarId/{carId}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int carId)
        {
            ViewBag.CarId = carId; // View'da kullanacağız

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7266/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateFeatureByCarId")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(int carId, List<int> SelectedFeatureIds)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var featureId in SelectedFeatureIds)
            {
                var newCarFeature = new CreateCarFeatureDto
                {
                    CarId = carId,
                    FeatureId = featureId,
                    Available = true
                };

                var jsonData = JsonConvert.SerializeObject(newCarFeature);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:7266/api/CarFeatures", content);
            }

            return RedirectToAction("Index", "AdminCar");
        }


    }
}
