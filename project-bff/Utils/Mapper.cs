using AutoMapper;
using ProjectBff.Contracts;
using ProjectBff.Domain;
using ProjectBff.Models;

namespace ProjectBff.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFeeRequest, Fee>();
        CreateMap<Fee, Fees>();
        
        CreateMap<CreateProjectRequest, Project>();
        CreateMap<Project, Projects>();
        CreateMap<QuoteRequest, Quote>();
        CreateMap<Quote, Quotes>();
        CreateMap<CostRequest, Cost>();
        CreateMap<Cost, Costs>();
        CreateMap<ItemRequest, Item>();
        CreateMap<Item, Items>();
    }
}