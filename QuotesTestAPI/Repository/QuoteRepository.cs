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
            return _context.Quotes.ToList();
        }

        public Quote GetQuotesById(int id)
        {
            return _context.Quotes.Where(q => q.Id == id).FirstOrDefault();
        }
    }
}
