using DataLayer.Dapper;

using ShipmentApp.Domain.Dtos.Shipment;
using ShipmentApp.Infrastructure.Context;

namespace ShipmentApp.Application.Services.Shipment
{
    public class ShipmentService : IShipmentService
    {
        private readonly ShipmentContext _context;
        private readonly IDapperConfig _dapper;

        public ShipmentService(ShipmentContext context, IDapperConfig dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<List<ShipperShipmentDetailDto>> GetShipmentDetail(int shipperId)
        {
            var shipperShipments = await _dapper.QueryAsync<ShipperShipmentDetailDto>("dbo.Shipper_Shipment_Details",
                new { @shipper_id = shipperId },
                System.Data.CommandType.StoredProcedure);

            return shipperShipments.ToList();
        }
    }
}
