using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Classes
{
    public class AnalyseClass : ObservableObject
    {
        private int numberOfOccurences;

        public int NumberOfOccurences
        {
            get { return numberOfOccurences; }
            set { 
                numberOfOccurences = value;
                OnPropertyChanged();
            }
        }

        private long process;

        public long Process
        {
            get { return process; }
            set { process = value; }
        }



        public void StartAnalyse()
        {
            Clear();

        }


        private void Clear()
        {
            NumberOfOccurences = 0;
            Process = 0;
        }



    }
}
