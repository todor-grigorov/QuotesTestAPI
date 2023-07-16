using AutoMapper;
using QuotesTestAPI.Dto;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Quote, QuoteDto>().ReverseMap();
        }
    }
}
