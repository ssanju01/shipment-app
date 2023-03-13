using Microsoft.Extensions.Configuration;
using ShipmentApp.Application.Services.Http;
using ShipmentApp.Domain.Dtos.Quotes;
using ShipmentApp.Domain.Models;

namespace ShipmentApp.Application.Services.Quotes
{
    public class QuoteService : IQuoteService
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;

        public QuoteService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<QuoteDto> GetRandomQuote()
        {
            var url = $"{_configuration.GetSection("AppSettings:QuoteAPI").Value}random";
            return await _httpService.GetAsync<QuoteDto>(url);
        }

        public async Task<SearchQuotesDto> SearchQuote(FilterModel filters)
        {
            var url = $"{_configuration.GetSection("AppSettings:QuoteAPI").Value}quotes?limit={filters.Limit}&author={filters.Author}&minLength={filters.MinLength}&maxLength={filters.MaxLength}";
            return await _httpService.GetAsync<SearchQuotesDto>(url);
        }
    }
}
