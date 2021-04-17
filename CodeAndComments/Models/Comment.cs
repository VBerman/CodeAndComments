using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class Comment : ObservableObject
    {
        private string locationFile;

        public string LocationFile
        {
            get { return locationFile; }
            set { locationFile = value; }
        }

        public string TextFile { get => File.ReadAllText(LocationFile); }

        private string textComment;

        public string TextComment
        {
            get { return textComment; }
            set
            {
                textComment = value;
                OnPropertyChanged();
                
            }
        }

    }
}
