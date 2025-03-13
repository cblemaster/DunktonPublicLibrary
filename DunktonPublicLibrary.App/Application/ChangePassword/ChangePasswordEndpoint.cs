
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public static class ChangePasswordEndpoint
{
    public static void MapChangePasswordEndpoint(this WebApplication app) =>
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
        }).RequireAuthorization(AppConstants.AUTH_REQUIRED_POLICY_NAME);
}
