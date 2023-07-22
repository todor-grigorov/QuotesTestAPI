using QuotesTestAPI.Models;

namespace QuotesTestAPI.Interfacecs
{
    public interface IQuotesRepository
    {
        ICollection<Quote> GetQuotes();
        Quote GetQuotesById(int id);
        void CreateQuote(Quote quote);
        void UpdateQuote(Quote quote);
        bool QuoteExists(int id);
        bool Save();
    }
}
