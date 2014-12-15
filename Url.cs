//************************************************************************************
//
// This is a stripped down version of Flurl's Url class. The project can be found at
// https://github.com/tmenier/Flurl/blob/master/Flurl/Util/CommonExtensions.cs
// 
// I claim no ownership of this code.
//
//************************************************************************************

using System;
using System.Collections.Generic;

namespace MTSharp
{

    /// <summary>
    /// Represents a URL that can be built fluently
    /// </summary>
    public class Url
    {
        /// <summary>
        /// The full absolute path part of the URL (everthing except the query string).
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Collection of all query string parameters.
        /// </summary>
        public IDictionary<string, object> QueryParams { get; private set; }

        /// <summary>
        /// Constructs a Url object from a string.
        /// </summary>
        /// <param name="baseUrl">The URL to use as a starting point (required)</param>
        public Url(string baseUrl)
        {
            if (baseUrl == null)
                throw new ArgumentNullException("baseUrl");

            var parts = baseUrl.Split('?');
            Path = parts[0];
        }

        /// <summary>
        /// Basically a Path.Combine for URLs. Ensures exactly one '/' character is used to seperate each segment.
        /// URL-encodes illegal characters but not reserved characters.
        /// </summary>
        /// <param name="url">The URL to use as a starting point (required).</param>
        /// <param name="segments">Paths to combine.</param>
        /// <returns></returns>
        public static string Combine(string url, params string[] segments)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            return new Url(url).AppendPathSegments(segments).ToString();
        }

        /// <summary>
        /// Encodes characters that are illegal in a URL path, including '?'. Does not encode reserved characters, i.e. '/', '+', etc.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private static string CleanSegment(string segment)
        {
            // http://stackoverflow.com/questions/4669692/valid-characters-for-directory-part-of-a-url-for-short-links
            var unescaped = Uri.UnescapeDataString(segment);
            return Uri.EscapeUriString(unescaped).Replace("?", "%3F");
        }

        /// <summary>
        /// Appends a segment to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segment">The segment to append</param>
        /// <param name="encode">If true, URL-encode the segment where necessary</param>
        /// <returns>the Url object with the segment appended</returns>
        public Url AppendPathSegment(string segment)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");

            if (!Path.EndsWith("/")) Path += "/";
            Path += CleanSegment(segment.TrimStart('/').TrimEnd('/'));
            return this;
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public Url AppendPathSegments(params string[] segments)
        {
            foreach (var segment in segments)
                AppendPathSegment(segment);

            return this;
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public Url AppendPathSegments(IEnumerable<string> segments)
        {
            foreach (var s in segments)
                AppendPathSegment(s);

            return this;
        }

        /// <summary>
        /// Converts this Url object to its string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var url = Path;

            return url;
        }

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        /// <param name="url">the Url object</param>
        /// <returns>The string</returns>
        public static implicit operator string(Url url)
        {
            return url.ToString();
        }
    }
}