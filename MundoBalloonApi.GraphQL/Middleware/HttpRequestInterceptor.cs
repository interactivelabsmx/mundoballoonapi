using System.Security.Claims;
using HotChocolate.AspNetCore;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Middleware;

public static class HttpRequestInterceptor
{
    public static HttpRequestInterceptorDelegate GetHttpRequestInterceptorDelegate()
    {
        return (httpContext, _, queryBuilder, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested) return ValueTask.FromCanceled(cancellationToken);
            // Language
            var acceptLanguage = httpContext.Request.Headers.AcceptLanguage.ToString();
            var lang = acceptLanguage.Contains('-') ? acceptLanguage.Split('-')[0] : acceptLanguage;
            var language = string.IsNullOrEmpty(acceptLanguage) ? "en" : lang;
            queryBuilder.SetProperty("language", language);
            // Authentication
            queryBuilder.AddProperty("currentUser", "unauthorized");
            if (!httpContext.User.Identity!.IsAuthenticated) return ValueTask.CompletedTask;
            var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            queryBuilder.SetProperty("currentUser", new CurrentUser(userId));

            return ValueTask.CompletedTask;
        };
    }
}