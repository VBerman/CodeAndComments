using CodeAndComments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Classes
{
    public class ViewModel
    {
        private static ApplicationViewModel instance;

        public ViewModel()
        {

        }

        public static ApplicationViewModel Instance 
        {
            get
            {
                instance = instance ?? new ApplicationViewModel();
                return instance;
            }
        }

    }
}
