using Microsoft.AspNetCore.Mvc;
using ShipmentApp.Application.Services.Shipper;
using ShipmentApp.Domain.Dtos.Shipper;

namespace ShipmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipperController : ControllerBase
    {

        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        public async Task<List<ShipperDto>> Get()
        {
            return await _shipperService.GetAllShippers();
        }
    }
}