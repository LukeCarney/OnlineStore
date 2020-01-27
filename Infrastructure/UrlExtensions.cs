using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathandQuery(this HttpRequest request) =>
            request.QueryString.HasValue ?
            $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
}
