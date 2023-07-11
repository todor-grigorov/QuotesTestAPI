using QuotesTestAPI.Models;

namespace QuotesTestAPI.Interfacecs
{
    public interface IQuotesRepository
    {
        ICollection<Quote> GetQuotes();
    }
}
