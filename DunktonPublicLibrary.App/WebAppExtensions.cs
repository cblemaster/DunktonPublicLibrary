
using DunktonPublicLibrary.App.Application;
using DunktonPublicLibrary.App.Application.ChangePassword;
using DunktonPublicLibrary.App.Application.Register;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App;

public static class WebAppExtensions
{
    public static void GetEnpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Welcome to Dunkton Public Library!");
        app.MapPost("/register", handler: async Task<Results<BadRequest<string>, InternalServerError, Created>> (RegisterCommand command, IMediator mediator) =>
        {
            RegisterResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
                ResponseType.Success => TypedResults.Created(),
                _ => TypedResults.InternalServerError(),
            };
        });
        app.MapPut("/account/{id:guid}/changepassword", handler: async Task<Results<BadRequest<string>, UnauthorizedHttpResult, InternalServerError>> (ChangePasswordCommand command, IMediator mediator) =>
        {
            ChangePasswordResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
                ResponseType.AuthenticationError => TypedResults.Unauthorized(),
                _ => TypedResults.InternalServerError(),
            };
        });
    }
}
