﻿namespace QuotesTestAPI.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
    }
}
