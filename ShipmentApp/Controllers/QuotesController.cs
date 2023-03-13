using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentApp.Application.Services.Quotes;
using ShipmentApp.Domain.Models;

namespace ShipmentApp.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomQuotes()
        {
            var response = await _quoteService.GetRandomQuote();
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchQuotes([FromQuery]FilterModel filters)
        {
            var response = await _quoteService.SearchQuote(filters);
            return Ok(response);
        }
    }
}
