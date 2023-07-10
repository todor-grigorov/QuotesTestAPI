using QuotesTestAPI.Interfacecs;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Repository
{
    public class QuoteRepository : IQuotesRepository
    {
        public ICollection<Quote> GetQuotes()
        {
            throw new NotImplementedException();
        }
    }
}
