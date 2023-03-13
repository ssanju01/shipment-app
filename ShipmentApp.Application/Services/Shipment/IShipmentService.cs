using ShipmentApp.Domain.Dtos.Shipment;

namespace ShipmentApp.Application.Services.Shipment
{
    public interface IShipmentService
    {
        Task<List<ShipperShipmentDetailDto>> GetShipmentDetail(int shipperId);
    }
}
