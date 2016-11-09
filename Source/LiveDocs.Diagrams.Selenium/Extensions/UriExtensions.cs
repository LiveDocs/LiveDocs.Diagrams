namespace LiveDocs.Diagrams.Selenium.Extensions
{
    using System;

    public static class UriExtensions
    {
        public static string Relative(this Uri uri, string relativeUri)
        {
            var hostUriAsString = uri.OriginalString.EndsWith("/")
                ? uri.OriginalString
                : $"{uri.OriginalString}/";

            return relativeUri.StartsWith("http")
                ? relativeUri
                : $"{hostUriAsString}{relativeUri}";
        }
    }
}