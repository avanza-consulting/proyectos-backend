namespace ProjectBff.Utils;

public class MappingProfile : Profile
{
    public MappingProfile(string databaseProvider)
    {
        AddRequestMappings();
        AddDatabaseProviderMappings(databaseProvider);
    }

    private void AddRequestMappings()
    {
        CreateMap<CreateFeeRequest, Fee>();
        CreateMap<CreateProjectRequest, Project>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        CreateMap<QuoteRequest, Quote>();
        CreateMap<CostRequest, Cost>();
        CreateMap<ItemRequest, Item>();
    }

    private void AddDatabaseProviderMappings(string databaseProvider)
    {
        if (databaseProvider == nameof(DatabaseProviders.SqlServer))
        {
            CreateMap<Fee, SqlServerFees>();
            CreateMap<Project, SqlServerProjects>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<Quote, SqlServerQuotes>();
            CreateMap<Cost, SqlServerCosts>();
            CreateMap<Item, SqlServerItems>();
        }
        else if (databaseProvider == nameof(DatabaseProviders.Supabase))
        {
            CreateMap<Fee, SupabaseFees>();
            CreateMap<Project, SupabaseProjects>();
            CreateMap<Quote, SupabaseQuotes>();
            CreateMap<Cost, SupabaseCosts>();
            CreateMap<Item, SupabaseItems>();
        }
    }
}