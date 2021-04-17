using CodeAndComments.Classes;
using CodeAndComments.Windows;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace CodeAndComments.Models
{
    public class ApplicationViewModel : ObservableObject
    {
        public ApplicationViewModel()
        {
            CurrentProject = new ProjectStorage();
            Templates = new ObservableCollection<Template>();
            Settings = new ObservableCollection<Setting>();
            SavedResults = new ObservableCollection<ViewAnalyseClass>();

            LoadTemplates();
            LoadSavedResult();

            try
            {
                Template = Templates[0];
            }
            catch (Exception)
            {

                File.WriteAllText(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json", Properties.Resources.StandartJSON);
                LoadTemplates();
                Template = Templates[0];
            }

            CreateNewSettings();

            
      



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


        public RelayCommand analyseCommand;
        public RelayCommand AnalyseCommand
        {
            get
            {
                return analyseCommand ??
                    (analyseCommand = new RelayCommand(async obj =>
                    {
                        Analyse = new AnalyseClass();
                        await Task.Run(() => Analyse.StartAnalyse(new ObservableCollection<Setting>(Settings.Where(a => a.IsUsage).ToList()), Template, CurrentProject));
                    }
                    ));
            }
        }


        //public RelayCommand viewResultCommand;
        //public RelayCommand ViewResultCommand
        //{
        //    get
        //    {
        //        return viewResultCommand ??
        //            (viewResultCommand = new RelayCommand(obj =>
        //            {

        //            }
        //            ));
        //    }
        //}


        //
        public void CreateNewSettings()
        {
            try
            {
                Settings = new ObservableCollection<Setting>() { };
                foreach (var item in this.Template.TemplateDetails)
                {
                    Settings.Add(new Setting(item));
                };
            }
            catch (Exception)
            {

                MessageBox.Show("Error template");
            }

        }

        private Template template;

        public Template Template
        {
            get { return template; }
            set
            {
                template = value;
                OnPropertyChanged();
                CreateNewSettings();
            }
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


        public void LoadTemplates()
        {
            CheckTemplatePath();
            Templates.Clear();
            foreach (var fileName in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Templates"))
            {
                //need remove and fix choose files window
                if (fileName.EndsWith(".json"))
                {
                    try
                    {
                        Templates.Add(new Template() { Path = fileName });
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error template: " + fileName);
                    }

                }

            }

        }




        public void LoadSavedResult()
        {
            CheckResultsPath();
            SavedResults.Clear();
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Results");
            foreach (var file in directoryInfo.GetFiles("*.json"))
            {
                //need remove and fix choose files window

                try
                {
                    SavedResults.Add(new ViewAnalyseClass() { Name = file.Name, FilePath = file.FullName });
                }
                catch (Exception)
                {

                    MessageBox.Show("Error template: " + file.Name);
                }



            }

        }


        public static void CheckTemplatePath()
        {
            bool exists = Directory.Exists(Directory.GetCurrentDirectory() + @"\Templates");

            if (!exists || !File.Exists(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Templates");
                //var standardTemplate = File.Create(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json");
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json", Properties.Resources.StandartJSON);

            }
        }

        public static void CheckResultsPath()
        {
            bool exists = Directory.Exists(Directory.GetCurrentDirectory() + @"\Results");
            if (!exists)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Results");



            }
        }

        private ObservableCollection<ViewAnalyseClass> savedResults;

        public ObservableCollection<ViewAnalyseClass> SavedResults
        {
            get { return savedResults; }
            set
            {
                savedResults = value;
                OnPropertyChanged();
            }
        }

        private ViewAnalyseClass currentAnalyseResult;

        public ViewAnalyseClass CurrentAnalyseResult
        {
            get { return currentAnalyseResult; }
            set
            {
                currentAnalyseResult = value;
                OnPropertyChanged();
            }
        }



    }
}
