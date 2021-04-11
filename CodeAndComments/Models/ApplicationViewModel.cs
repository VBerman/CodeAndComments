using CodeAndComments.Classes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CodeAndComments.Models
{
    class ApplicationViewModel : ObservableObject
    {

        
        public ApplicationViewModel()
        {
            CurrentProject = new ProjectStorage();
        }

        private ProjectStorage currentProject;

        public ProjectStorage CurrentProject
        {
            get => currentProject;
            set { 
                currentProject = value;
                OnPropertyChanged(nameof(CurrentProject));
            }
        }


        private RelayCommand chooseProject;

        public RelayCommand ChooseProject
        {
            get {
                return chooseProject ??
                    (chooseProject = new RelayCommand(obj =>
                    {
                        var dialog = new CommonOpenFileDialog("Choose path project");
                        dialog.IsFolderPicker = true;


                        

                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok) 
                        {
                            CurrentProject.Address = dialog.FileName;
                        }
                    }
                    ));
            }
            
        }

        public bool? DialogResult { get; private set; }
    }
}
