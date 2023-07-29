using QuotesTestAPI.Models;

namespace QuotesTestAPI.Interfacecs
{
    public interface IQuotesRepository
    {
        ICollection<Quote> GetQuotes();
        Quote GetQuotesById(int id);
        bool CreateQuote(Quote quote);
        bool UpdateQuote(Quote quote);
        void DeleteQuote(Quote quote);
        bool QuoteExists(int id);
        bool Save();
    }
}
