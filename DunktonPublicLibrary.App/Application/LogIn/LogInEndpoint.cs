
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App.Application.LogIn;

public static class LogInEndpoint
{
    public static void MapLogInEndpoint(this WebApplication app) => 
        app.MapPut("/login", handler: async Task<Results<BadRequest<string>, UnauthorizedHttpResult, NoContent, InternalServerError>> (LogInCommand command, IMediator mediator) =>
        {
            LogInResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
                ResponseType.AuthenticationError => TypedResults.Unauthorized(),
                ResponseType.Success => TypedResults.NoContent(),
                _ => TypedResults.InternalServerError(),
                // TODO: the response message has the token...
            };
        });
}
