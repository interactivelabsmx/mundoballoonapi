using System.Security.Claims;
using HotChocolate.AspNetCore;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Middleware;

public static class AuthenticationInterceptor
{
    public static HttpRequestInterceptorDelegate GetAuthenticationInterceptor()
    {
        return (httpContext, _, queryBuilder, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested) return ValueTask.FromCanceled(cancellationToken);
            queryBuilder.AddProperty("currentUser", "unauthorized");
            if (!httpContext.User.Identity!.IsAuthenticated) return ValueTask.CompletedTask;
            var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            queryBuilder.SetProperty("currentUser", new CurrentUser(userId));
            return ValueTask.CompletedTask;
        };
    }
}