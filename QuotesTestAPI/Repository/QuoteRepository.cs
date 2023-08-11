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

        public bool CreateQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            return Save();
        }

        public bool DeleteQuote(Quote quote)
        {
            _context.Remove(quote);
           return Save();
        }

        public IQueryable<Quote> GetQuotesDescending()
        {
            return _context.Quotes.OrderByDescending(q => q.CreatedAt);
        }

        public IQueryable<Quote> GetQuotesAscdending()
        {
            return _context.Quotes.OrderBy(q => q.CreatedAt);
        }

        public ICollection<Quote> GetQuotes()
        {
            return _context.Quotes.ToList();
        }

        public Quote GetQuotesById(int id)
        {
            return _context.Quotes.Where(q => q.Id == id).FirstOrDefault();
        }

        public bool QuoteExists(int id)
        {
            return _context.Quotes.Any(q => q.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateQuote(Quote quote)
        {
            _context.Update(quote);
            return Save();
        }

       
    }
}
