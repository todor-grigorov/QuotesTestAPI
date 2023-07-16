using Microsoft.AspNetCore.Mvc;
using QuotesTestAPI.Interfacecs;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IQuotesRepository _quotesRepository;

        public QuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesRepository.GetQuotes();
        }
    }
}
