using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection.Levels.Commands.CreateLevel;
using Microsoft.Extensions.DependencyInjection.Levels.Commands.UpdateLevel;
using Microsoft.Extensions.DependencyInjection.Levels.Queries.GetLevelsWithPagination;

namespace CleanArchitecture.Web.Endpoints
{
    public class Levels : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapPost(CreateLevel)
                .MapPut(UpdateLevel, "{id}")
                .MapGet(GetLevels);

        }

        public async Task<Created<Level>> CreateLevel(CreateLevelCommand command, ISender sender)
        {
            var level = await sender.Send(command);
            return TypedResults.Created<Level>("created succufuly",level);
        }

        public async Task<Results<NoContent, BadRequest>> UpdateLevel(ISender sender, int id,
            UpdateLevelCommand command)
        {
            if (id != command.Id) return TypedResults.BadRequest();
            await sender.Send(command);
            return TypedResults.NoContent();
        }

        public async Task<Ok<List<LevelDto>>> GetLevels( ISender sender)
        {
            var result =  await sender.Send(new GetLevels.GetLevelsQuery());
            return TypedResults.Ok(result);
            
        }
    }
}
