using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

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

        private FileStorage file;

        public FileStorage File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged();
            }
        }

        private string errorString;

        public string ErrorString
        {
            get { return errorString; }
            set
            {
                errorString = value;
                OnPropertyChanged();
            }
        }


        private bool? correctly;

        public bool? Correctly
        {
            get { return correctly; }
            set
            {
                correctly = value;

                OnPropertyChanged();
            }
        }

        public string FileText
        {
            get
            {
                return System.IO.File.ReadAllText(File.CurrentFile);
            }
        }



    }
}
