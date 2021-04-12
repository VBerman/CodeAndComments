using CodeAndComments.Classes;
using CodeAndComments.Windows;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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




        private AnalyseClass analyse;

        public AnalyseClass Analyse
        {
            get { return analyse; }
            set
            {
                analyse = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Setting> settings;

        public ObservableCollection<Setting> Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }



        private ProjectStorage currentProject;

        public ProjectStorage CurrentProject
        {
            get => currentProject;
            set
            {
                currentProject = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand chooseProject;

        public RelayCommand ChooseProject
        {
            get
            {
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
                        new ChooseFilesWindow().Show();

                    }
                    ));
            }

        }


        //
        public void CreateNewSettings()
        {
            Settings = new ObservableCollection<Setting>()
            {
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Classes")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Fields")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Methods")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Properties")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Comments")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Interfaces")),
                new Setting(Template.TemplateDetails.FirstOrDefault(t => t.Name == "Structers"))
            };
        }

        private Template template;

        public Template Template
        {
            get { return template; }
            set { template = value; }
        }

        private ObservableCollection<Template> templates;

        public ObservableCollection<Template> Templates
        {
            get { return templates; }
            set
            {
                templates = value;
                OnPropertyChanged();
            }
        }



    }
}
