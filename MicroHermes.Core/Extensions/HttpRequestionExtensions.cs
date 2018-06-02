using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;

namespace MicroHermes.Core.Extensions
{
    public static class HttpRequestionExtensions
    {

        public static string GetBaseUri(this HttpRequest request)
        {
            return request?.GetUri().AbsoluteUri.Replace(request.GetUri().AbsolutePath, string.Empty);
        }
    }
}