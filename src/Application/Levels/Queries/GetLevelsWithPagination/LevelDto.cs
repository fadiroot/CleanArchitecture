using CleanArchitecture.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Levels.Queries.GetLevelsWithPagination;

public class LevelDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Level, LevelDto>();
        }
        
    }
    
}
