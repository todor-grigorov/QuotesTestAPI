using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuoteDto>))]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            var quotesResult = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotes());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(quotesResult);
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200, Type = typeof(QuoteDto))]
        [ProducesResponseType(400)]
        public IActionResult Get(int id)
        {
            var quote = _mapper.Map<QuoteDto>(_quotesRepository.GetQuotesById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(quote);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]QuoteDto quoteCreate)
        { 
            if (quoteCreate == null)
                return BadRequest(ModelState);

            var quote = _quotesRepository.GetQuotes().Where(q => q.Title.Trim().ToUpper() == quoteCreate.Title.Trim().ToUpper() 
                        && q.Description.Trim().ToUpper() == quoteCreate.Description.Trim().ToUpper())
                        .FirstOrDefault();


            if (quote != null)
            {
                ModelState.AddModelError("", "Quote already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var quoteMap = _mapper.Map<Quote>(quoteCreate);
            _quotesRepository.CreateQuote(quoteMap);

            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]QuoteDto updateQuote)
        {
            var quoteMap = _mapper.Map<Quote>(updateQuote);
            _quotesRepository.UpdateQuote(quoteMap);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var quote = _quotesRepository.GetQuotesById(id);
            _quotesRepository.DeleteQuote(quote);
        }
    }
}
