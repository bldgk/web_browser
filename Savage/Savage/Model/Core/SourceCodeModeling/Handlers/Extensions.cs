using Savage.Core.SourceCodeModeling.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Savage.Core.SourceCodeModeling.Handlers
{
    internal static class HelperExtensions
    {
        static HtmlEncoder encoder = new HtmlEncoder();

        public static Match MatchAtIndex(this Regex r, string input, int index)
        {
            Regex newRegex = new Regex(string.Format("^(?:{0})", r));
            return newRegex.Match(input.Substring(index));
        }

        public static string HtmlDecode(this string html)
        {
            return encoder.Decode(html);
        }
    }
}
