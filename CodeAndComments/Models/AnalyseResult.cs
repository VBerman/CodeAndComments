using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class AnalyseResult : ObservableObject
    {
        public AnalyseResult()
        {

        }

        private string nameError;

        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                OnPropertyChanged();
            }
        }

        private int countCorrect;

        public int CountCorrect
        {
            get { return countCorrect; }
            set
            {
                countCorrect = value;
                OnPropertyChanged();
            }
        }

        private int countIncorrect;

        public int CountIncorrect
        {
            get { return countIncorrect; }
            set
            {
                countIncorrect = value;
                OnPropertyChanged();
                OnPropertyChanged("GetPercentIncorrect");

            }
        }

        private int notResolved;

        public int NotResolved
        {
            get { return notResolved; }
            set
            {
                notResolved = value;
                OnPropertyChanged();
            }
        }

        public double GetPercentIncorrect
        {
            get => (double)CountIncorrect * 100 / (CountCorrect + CountIncorrect);
        }
    }
}
