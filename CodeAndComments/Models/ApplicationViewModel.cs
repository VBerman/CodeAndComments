using CodeAndComments.Classes;
using CodeAndComments.Windows;
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
    public class ApplicationViewModel : ObservableObject
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

        private RelayCommand openChooseFilesWindow;

        public RelayCommand OpenChooseFilesWindow
        {
            get
            {
                return openChooseFilesWindow ??
                    (openChooseFilesWindow = new RelayCommand(obj =>
                    {
                        var chooseFilesWindow = new ChooseFilesWindow(this);
                        chooseFilesWindow.Show();
                    }
                    ));
            }

        }

        public bool? DialogResult { get; private set; }

        

    }
}
