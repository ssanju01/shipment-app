using ShipmentApp.Domain.Dtos.Quotes;
using ShipmentApp.Domain.Models;

namespace ShipmentApp.Application.Services.Quotes
{
    public interface IQuoteService
    {
        Task<QuoteDto> GetRandomQuote();
        Task<SearchQuotesDto> SearchQuote(FilterModel filters);
    }
}
