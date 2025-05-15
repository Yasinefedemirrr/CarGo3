
using CarGo.Application.Features.CQRS.Commands.CarCommands;
using CarGo.Application.Features.CQRS.Handlers.CarHandlers;
using CarGo.Application.Features.CQRS.Queries.CarQueries;
using CarGo.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarsWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler _getLAst5CarsWithBrandQueryHandler;



        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLAst5CarsWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarsWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLAst5CarsWithBrandQueryHandler = getLAst5CarsWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCar(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araba Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba Bilgisi Güncellendi");
        }
        [HttpGet("GetCarWithBrand")]
        public  IActionResult GetCarWithBrand()
        {
            var values = _getCarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("GetLast5CarWithBrandQueryHandler")]
        public IActionResult GetLast5CarWithBrandQueryHandler()
        {
            var values = _getLAst5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}

