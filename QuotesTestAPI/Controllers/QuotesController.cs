using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuotesTestAPI.Dto;
using QuotesTestAPI.Interfacecs;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper;

        public QuotesController(IQuotesRepository quotesRepository, IMapper mapper)
        {
            _quotesRepository = quotesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<QuoteDto> Get()
        {
            var quotes = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotes());
            return quotes;
        }

        [HttpGet("{id}", Name = "Get")]
        public Quote Get(int id)
        {
            return _quotesRepository.GetQuotesById(id);
        }
    }
}
