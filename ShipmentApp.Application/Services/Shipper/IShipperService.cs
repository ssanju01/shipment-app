using ShipmentApp.Domain.Dtos.Shipper;

namespace ShipmentApp.Application.Services.Shipper
{
    public interface IShipperService
    {
        Task<List<ShipperDto>> GetAllShippers();
    }
}
