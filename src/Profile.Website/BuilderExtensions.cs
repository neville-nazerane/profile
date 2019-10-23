using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Website
{
    public static class BuilderExtensions
    {

        public static IWebHostBuilder UseUrlsIfExists(this IWebHostBuilder builder)
        {
            var urls = Environment.GetEnvironmentVariable("DOCS_URLS")?.Split(",");
            if (urls != null) return builder.UseUrls(urls);
            return builder;
        }

    }
}
