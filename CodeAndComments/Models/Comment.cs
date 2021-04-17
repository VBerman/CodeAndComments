using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
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
