using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection.Levels.Commands.CreateLevel;

namespace CleanArchitecture.Web.Endpoints
{
    public class Levels : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapPost(CreateLevel);
            
        }

        public async Task<Created<Level>> CreateLevel(CreateLevelCommand command, ISender sender)
        {
            var level = await sender.Send(command);
            return TypedResults.Created<Level>("created succufuly",level);
        }
    }
}
