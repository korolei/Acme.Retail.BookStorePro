using Acme.Retail.BookStorePro.Parties;
using AutoMapper;

namespace Acme.Retail.BookStorePro.Blazor
{
    public class BookStoreProBlazorAutoMapperProfile : Profile
    {
        public BookStoreProBlazorAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Blazor project.

            CreateMap<PartyDto, PartyUpdateDto>();
        }
    }
}