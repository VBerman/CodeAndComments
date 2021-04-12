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

        public static void Parse(string expression, string text)
        {
            var regex = new Regex(expression);

            var matches = regex.Matches(text);

            foreach (var match in matches)
            {

            }
        }

    }
}
