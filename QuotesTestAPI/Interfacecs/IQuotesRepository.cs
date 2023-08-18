using QuotesTestAPI.Models;

namespace QuotesTestAPI.Interfacecs
{
    public interface IQuotesRepository
    {
        ICollection<Quote> GetQuotes();
        ICollection<Quote> GetQuotesDescending();
        ICollection<Quote> GetQuotesAscdending();
        Quote GetQuotesById(int id);
        ICollection<Quote> SearchQuotes(string searchTerm);
        bool CreateQuote(Quote quote);
        bool UpdateQuote(Quote quote);
        bool DeleteQuote(Quote quote);
        bool QuoteExists(int id);
        bool Save();
    }
}
