using Microsoft.Extensions.DependencyInjection;
using ShipmentApp.Application.Services.Http;
using ShipmentApp.Application.Services.Quotes;
using ShipmentApp.Application.Services.Shipment;
using ShipmentApp.Application.Services.Shipper;

namespace ShipmentApp.Application.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationAssembly(this IServiceCollection services)
        {
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IHttpService, HttpService>();

            return services;
        }
    }
}
