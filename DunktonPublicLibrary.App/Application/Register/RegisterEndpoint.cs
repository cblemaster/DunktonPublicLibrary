
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App.Application.Register;

public static class RegisterEndpoint
{
    public static void MapRegisterEndpoint(this WebApplication app) =>
        app.MapPost("/register", handler: async Task<Results<BadRequest<string>, NoContent, InternalServerError>> (RegisterCommand command, IMediator mediator) =>
        {
            RegisterResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
                ResponseType.Success => TypedResults.NoContent(),
                _ => TypedResults.InternalServerError(),
            };
        });
}
