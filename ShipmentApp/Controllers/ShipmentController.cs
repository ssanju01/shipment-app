using Microsoft.AspNetCore.Mvc;

using ShipmentApp.Application.Services.Shipment;
using ShipmentApp.Domain.Dtos.Shipment;

namespace ShipmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }


        [HttpGet]
        public async Task<List<ShipperShipmentDetailDto>> Get(int id)
        {
            var list = await _shipmentService.GetShipmentDetail(id);

            return list;
        }

    }
}
