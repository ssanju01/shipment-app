using Microsoft.EntityFrameworkCore;

using ShipmentApp.Domain.Dtos.Shipper;
using ShipmentApp.Infrastructure.Context;

namespace ShipmentApp.Application.Services.Shipper
{
    public class ShipperService : IShipperService
    {
        private readonly ShipmentContext _context;

        public ShipperService(ShipmentContext context)
        {
            _context = context;
        }

        public async Task<List<ShipperDto>> GetAllShippers()
        {
            var list = await _context.Shippers
                .Select(x => new ShipperDto
                {
                    ShipperId = x.ShipperId,
                    ShipperName = x.ShipperName
                })
                .ToListAsync();

            return list;
        }

    }
}
