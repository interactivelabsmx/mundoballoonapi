using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using MundoBalloonApi.business.Dtos;

namespace MundoBalloonApi.graphql.Middleware
{
    public static class AuthenticationInterceptor
    {
        public static HttpRequestInterceptorDelegate GetAuthenticationInterceptor()
        {
            return (httpContext, _, queryBuilder, cancellationToken) =>
            {
                if (cancellationToken.IsCancellationRequested) return ValueTask.FromCanceled(cancellationToken);
                queryBuilder.AddProperty("currentUser", "unauthorized");
                if (!httpContext.User.Identity!.IsAuthenticated) return ValueTask.CompletedTask;
                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.ToString();
                var claims = httpContext.User.Claims.Select(x => $"{x.Type} : {x.Value}").ToList();
                queryBuilder.SetProperty("currentUser", new CurrentUser(userId, claims));
                return ValueTask.CompletedTask;
            };
        }
    }
}