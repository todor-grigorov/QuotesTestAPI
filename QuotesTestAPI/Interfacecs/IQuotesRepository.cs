﻿using QuotesTestAPI.Models;

namespace QuotesTestAPI.Interfacecs
{
    public interface IQuotesRepository
    {
        ICollection<Quote> GetQuotes();
        ICollection<Quote> GetQuotesDescending();
        ICollection<Quote> GetQuotesAscdending();
        Quote GetQuotesById(int id);
        bool CreateQuote(Quote quote);
        bool UpdateQuote(Quote quote);
        bool DeleteQuote(Quote quote);
        bool QuoteExists(int id);
        bool Save();
    }
}
