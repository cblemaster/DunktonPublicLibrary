
using DunktonPublicLibrary.App.Application;
using DunktonPublicLibrary.App.Application.ChangePassword;
using DunktonPublicLibrary.App.Application.LogIn;
using DunktonPublicLibrary.App.Application.LogOut;
using DunktonPublicLibrary.App.Application.Register;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App.Extensions;

public static class WebAppExtensions
{
    public static void GetEndpoints(this WebApplication app)
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
        app.MapPut("/logout", handler: async Task<Results<NoContent, InternalServerError>> (LogOutCommand command, IMediator mediator) =>
        {
            LogOutResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.Success => TypedResults.NoContent(),
                _ => TypedResults.InternalServerError(),
            };
        });
        app.MapPut("/changepassword", handler: async Task<Results<BadRequest<string>, UnauthorizedHttpResult, NoContent, InternalServerError>> (ChangePasswordCommand command, IMediator mediator) =>
        {
            ChangePasswordResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
                ResponseType.AuthenticationError => TypedResults.Unauthorized(),
                ResponseType.Success => TypedResults.NoContent(),
                _ => TypedResults.InternalServerError(),
            };
        });
    }
}
