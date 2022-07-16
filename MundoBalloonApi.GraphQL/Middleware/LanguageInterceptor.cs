using HotChocolate.AspNetCore;

namespace MundoBalloonApi.graphql.Middleware;

public static class LanguageInterceptor
{
    public static HttpRequestInterceptorDelegate GetLanguageInterceptor()
    {
        return (httpContext, _, queryBuilder, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested) return ValueTask.FromCanceled(cancellationToken);
            var acceptLanguage = httpContext.Request.Headers.AcceptLanguage.ToString();
            var lang = acceptLanguage.Contains('-') ? acceptLanguage.Split('-')[0] : acceptLanguage;
            var language = string.IsNullOrEmpty(acceptLanguage) ? "en" : lang;
            queryBuilder.SetProperty("language", language);
            return ValueTask.CompletedTask;
        };
    }
}