
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App.Application.LogOut;

public static class LogOutEndpoint
{
    public static void MapLogOutEndpoint(this WebApplication app) =>
        app.MapPut("/logout", handler: async Task<Results<NoContent, InternalServerError>> (LogOutCommand command, IMediator mediator) =>
        {
            LogOutResponse response = await mediator.Send(command);
            return response.ResponseType switch
            {
                ResponseType.Success => TypedResults.NoContent(),
                _ => TypedResults.InternalServerError(),
            };
        }).RequireAuthorization(AppConstants.AUTH_REQUIRED_POLICY_NAME);
}
