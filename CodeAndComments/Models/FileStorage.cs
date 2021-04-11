using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class FileStorage : ObservableObject
    {

        public FileStorage()
        {
            isCurrent = true;
        }

        private string currentFile;

        public string CurrentFile
        {
            get => currentFile;
            set
            {
                currentFile = value;
                OnPropertyChanged(nameof(CurrentFile));
            }
        }

        private bool isCurrent;

        public bool IsCurrent
        {
            get => isCurrent;
            set { 
                isCurrent = value;
                OnPropertyChanged(nameof(IsCurrent));
            }
        }

        private RelayCommand changeState;

        public RelayCommand ChangeState
        {
            get 
            {
                return changeState ??
                    (changeState = new RelayCommand(obj => 
                    {                        
                        IsCurrent = !IsCurrent; 

                    }
                    )); 
            }
            
        }



    }
}
