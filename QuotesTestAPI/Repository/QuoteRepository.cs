using QuotesTestAPI.Data;
using QuotesTestAPI.Interfacecs;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Repository
{
    public class QuoteRepository : IQuotesRepository
    {
        private readonly ApiDbContext _context;

        public QuoteRepository(ApiDbContext context)
        {
            _context = context;
        }

        public ICollection<Quote> GetQuotes()
        {
            throw new NotImplementedException();
        }
    }
}
