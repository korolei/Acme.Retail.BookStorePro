using Acme.Retail.BookStorePro.JudicialCaseAttributess;
using Acme.Retail.BookStorePro.Parties;
using System;
using Acme.Retail.BookStorePro.Shared;
using Acme.Retail.BookStorePro.JudicialCases;
using Volo.Abp.AutoMapper;
using AutoMapper;

namespace Acme.Retail.BookStorePro
{
    public class BookStoreProApplicationAutoMapperProfile : Profile
    {
        public BookStoreProApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<JudicialCaseCreateDto, JudicialCase>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<JudicialCaseUpdateDto, JudicialCase>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<JudicialCase, JudicialCaseDto>();

            CreateMap<PartyCreateDto, Party>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<PartyUpdateDto, Party>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Party, PartyDto>();

            CreateMap<JudicialCaseWithNavigationProperties, JudicialCaseWithNavigationPropertiesDto>();
            CreateMap<Party, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.PartyType));

            CreateMap<JudicialCaseAttributesCreateDto, JudicialCaseAttributes>().Ignore(x => x.Id);
            CreateMap<JudicialCaseAttributesUpdateDto, JudicialCaseAttributes>().Ignore(x => x.Id);
            CreateMap<JudicialCaseAttributes, JudicialCaseAttributesDto>();

            CreateMap<JudicialCaseAttributes, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Key));
        }
    }
}