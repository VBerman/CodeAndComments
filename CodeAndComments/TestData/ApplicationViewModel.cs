//using CodeAndComments.Classes;
//using CodeAndComments.Windows;
//using Microsoft.Win32;
//using Microsoft.WindowsAPICodePack.Dialogs;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Navigation;

//namespace CodeAndComments.Models
//{
//    public class ApplicationViewModel : ObservableObject
//    {
//        public ApplicationViewModel()
//        {
//            CurrentProject = new ProjectStorage();
//            Templates = new ObservableCollection<Template>();
//            Settings = new ObservableCollection<Setting>();
//            SavedResults = new ObservableCollection<AnalyseClass>();

//            LoadTemplates();
//            LoadSavedResult();
//            try
//            {
//                Template = Templates[0];
//                CreateNewSettings();
//            }
//            catch (Exception)
//            {

//            }
            
            

//        }




//        private AnalyseClass analyse;

//        public AnalyseClass Analyse
//        {
//            get { return analyse; }
//            set
//            {
//                analyse = value;
//                OnPropertyChanged();
//            }
//        }


//        private ObservableCollection<Setting> settings;

//        public ObservableCollection<Setting> Settings
//        {
//            get { return settings; }
//            set
//            {
//                settings = value;
//                OnPropertyChanged();
//            }
//        }



//        private ProjectStorage currentProject;

//        public ProjectStorage CurrentProject
//        {
//            get => currentProject;
//            set
//            {
//                currentProject = value;
//                OnPropertyChanged();
//            }
//        }


//        private RelayCommand chooseProject;

//        public RelayCommand ChooseProject
//        {
//            get
//            {
//                return chooseProject ??
//                    (chooseProject = new RelayCommand(obj =>
//                    {
//                        var dialog = new CommonOpenFileDialog("Choose path project");
//                        dialog.IsFolderPicker = true;




//                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
//                        {
//                            CurrentProject.Address = dialog.FileName;
//                        }
//                    }
//                    ));
//            }


//        }

//        private RelayCommand openChooseFilesWindow;

//        public RelayCommand OpenChooseFilesWindow
//        {
//            get
//            {
//                return openChooseFilesWindow ??
//                    (openChooseFilesWindow = new RelayCommand(obj =>
//                    {
//                        new ChooseFilesWindow().Show();

//                    }
//                    ));
//            }

//        }


//        public RelayCommand analyseCommand;
//        public RelayCommand AnalyseCommand
//        {
//            get
//            {
//                return analyseCommand ??
//                    (analyseCommand = new RelayCommand(async obj =>
//                    {
//                        Analyse = new AnalyseClass();
//                        await Task.Run(()=>Analyse.StartAnalyse(new ObservableCollection<Setting>(Settings.Where(a => a.IsUsage).ToList()), Template, CurrentProject));
//                    }
//                    ));
//            }
//        }


//        //public RelayCommand viewResultCommand;
//        //public RelayCommand ViewResultCommand
//        //{
//        //    get
//        //    {
//        //        return viewResultCommand ??
//        //            (viewResultCommand = new RelayCommand(obj =>
//        //            {
                        
//        //            }
//        //            ));
//        //    }
//        //}


//        //
//        public void reateNewSettings()
//        {
//            Settings = new ObservableCollection<Setting>()
//            {
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Classes")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Fields")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Methods")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Properties")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Comments")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Interfaces")),
//                new Setting(Template.TemplateDetails.First(t => t.Name == "Structures"))
//            };
//        }

//        private Template template;

//        public Template Template
//        {
//            get { return template; }
//            set { 
//                template = value;
//                OnPropertyChanged();
//            }
//        }

//        private ObservableCollection<Template> templates;

//        public ObservableCollection<Template> Templates
//        {
//            get { return templates; }
//            set
//            {
//                templates = value;
//                OnPropertyChanged();
//            }
//        }


//        public void oadTemplates()
//        {
//            CheckTemplatePath();
//            Templates.Clear();
//            foreach (var fileName in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Templates"))
//            {
//                //need remove and fix choose files window
//                if (fileName.EndsWith(".json"))
//                {
//                    try
//                    {
//                        Templates.Add(new Template() { Path = fileName });
//                    }
//                    catch (Exception ex)
//                    {

//                        MessageBox.Show("Error template: " + fileName);
//                    }
                    
//                }

//            }

//        }

//        public void oadSavedResult()
//        {
//            CheckResultsPath();
//            SavedResults.Clear();
//            foreach (var fileName in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Results"))
//            {
//                //need remove and fix choose files window
//                if (fileName.EndsWith(".json"))
//                {
//                    try
//                    {
//                        SavedResults.Add(JsonConvert.DeserializeObject<AnalyseClass>(File.ReadAllText(fileName)));
//                    }
//                    catch (Exception)
//                    {

//                        MessageBox.Show("Error template: " + fileName);
//                    }

//                }

//            }

//        }


//        public static void CheckTemplatePath()
//        {
//            bool exists = Directory.Exists(Directory.GetCurrentDirectory() + @"\Templates");
//            if (!exists)
//            {
//                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Templates");
//                //var standardTemplate = File.Create(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json");
//                File.WriteAllText(Directory.GetCurrentDirectory() + @"\Templates\StandardTemplate.json", Properties.Resources.StandartJSON);

//            }
//        }

//        public static void CheckResultsPath()
//        {
//            bool exists = Directory.Exists(Directory.GetCurrentDirectory() + @"\Results");
//            if (!exists)
//            {
//                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Results");
            
                

//            }
//        }

//        private ObservableCollection<AnalyseClass> savedResults;

//        public ObservableCollection<AnalyseClass> SavedResults
//        {
//            get { return savedResults; }
//            set { savedResults = value;
//                OnPropertyChanged();
//            }
//        }

//        private AnalyseClass currentAnalyseResult;

//        public AnalyseClass CurrentAnalyseResult
//        {
//            get { return currentAnalyseResult; }
//            set {
//                currentAnalyseResult = value;
//                OnPropertyChanged();
//            }
//        }



//    }
//}
