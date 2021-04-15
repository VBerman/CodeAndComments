using CodeAndComments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAndComments.Classes
{
    public class Parser
    {

        public static List<string> Parse(string expression, string text)
        {
            var regex = new Regex(expression);

            var matches = regex.Matches(text);

            var errors = new List<string>();
            
            foreach (Match match in (MatchCollection)matches)
            {
                
                errors.Add(match.Value.TrimEnd('\r'));
            }
            return errors;

        }

    }
}
