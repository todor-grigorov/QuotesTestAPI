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
        public QuoteDto Get(int id)
        {
            var quote = _mapper.Map<QuoteDto>(_quotesRepository.GetQuotesById(id));
            return quote;
        }

        [HttpPost]
        public void Post([FromBody]QuoteDto quoteCreate)
        {
            var quoteMap = _mapper.Map<Quote>(quoteCreate);
            _quotesRepository.CreateQuote(quoteMap);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]QuoteDto updateQuote)
        {
            var quoteMap = _mapper.Map<Quote>(updateQuote);
            _quotesRepository.UpdateQuote(quoteMap);
        }
    }
}
