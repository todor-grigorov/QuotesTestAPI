﻿using QuotesTestAPI.Data;
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

        public void CreateQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
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

        public void UpdateQuote(Quote quote)
        {
            _context.Update(quote);
            _context.SaveChanges();
        }
    }
}
