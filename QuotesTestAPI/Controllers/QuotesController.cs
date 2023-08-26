using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuotesTestAPI.Common;
using QuotesTestAPI.Dto;
using QuotesTestAPI.Interfacecs;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuoteDto>))]
        [ProducesResponseType(400)]
        public IActionResult Get(SortingOrder sort = SortingOrder.Default)
        {
            IEnumerable<QuoteDto> quotesResult;

            switch (sort)
            {
                case SortingOrder.Descending:
                    quotesResult = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotesDescending());
                    break;
                case SortingOrder.Ascending:
                    quotesResult = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotesAscdending());
                    break;
                default:
                    quotesResult = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotes());
                    break;
            }

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

        [HttpGet("/paging", Name = "GetPagingQuotes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuoteDto>))]
        [ProducesResponseType(400)]
        public IActionResult PagingQuotes(int page, int pageSize)
        {
            var quotesResult = _mapper.Map<IEnumerable<QuoteDto>>(_quotesRepository.GetQuotes().Skip((page - 1) * pageSize).Take(pageSize));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(quotesResult);
        }

        [HttpGet("/search", Name = "SearchQuote")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuoteDto>))]
        [ProducesResponseType(400)]
        public IActionResult SearchQuote(string serchTerm)
        {
            var quotesResult = _mapper.Map<IEnumerable<Quote>>(_quotesRepository.SearchQuotes(serchTerm));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(quotesResult);
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
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody]QuoteDto updateQuote)
        {
            if (updateQuote == null)
                return BadRequest(ModelState);

            if (id != updateQuote.Id)
                return BadRequest(ModelState);

            if (!_quotesRepository.QuoteExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var quoteMap = _mapper.Map<Quote>(updateQuote);
            
            if (!_quotesRepository.UpdateQuote(quoteMap))
            {
                ModelState.AddModelError("", "Something went wrong updating quote");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (!_quotesRepository.QuoteExists(id))
            {
                return NotFound();
            }


            var quoteToDelete = _quotesRepository.GetQuotesById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_quotesRepository.DeleteQuote(quoteToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting quote");
            }

            return NoContent();
        }
    }
}
