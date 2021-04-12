using CodeAndComments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Classes
{
    public class Analyse
    {
        public static AnalyseClass instance;

        public Analyse()
        {

        }

        public static AnalyseClass Instance
        {
            get
            {
                instance = instance ?? new AnalyseClass();
                return instance;
            }
        }

    }
}
