using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;

namespace Microsoft.Extensions.DependencyInjection.Levels.Queries.GetLevelsWithPagination;

public class GetLevels
{
    [Authorize]
    public record GetLevelsQuery : IRequest<List<LevelDto>>;

    public class GetLevelsQueryHandler : IRequestHandler<GetLevelsQuery, List<LevelDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLevelsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LevelDto>> Handle(GetLevelsQuery request, CancellationToken cancellationToken)
        {
            var Levels = await _context.Levels.AsNoTracking().ToListAsync();
            return _mapper.Map<List<LevelDto>>(Levels);
        }
    }
    
}
