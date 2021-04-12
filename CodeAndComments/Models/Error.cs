using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class Error : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string file;

        public string File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged();
            }
        }

        private bool correctly;

        public bool Correctly
        {
            get { return correctly; }
            set
            {
                correctly = value;
                
                OnPropertyChanged();
            }
        }



    }
}
