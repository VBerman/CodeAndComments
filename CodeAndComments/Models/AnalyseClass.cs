﻿using CodeAndComments.Classes;
using CodeAndComments.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class AnalyseClass : ObservableObject
    {
        public AnalyseClass()
        {
            ChooseSettings = new ObservableCollection<Setting>();
            Errors = new ObservableCollection<Error>();
        }

        private Error currentError;

        public Error CurrentError
        {
            get { return currentError; }
            set { 
                currentError = value;
                OnPropertyChanged();
            }
        }


        public long PercentOfIncorrectOccurences
        {
            get
            {
                return NumberOfIncorrectOccurences * 100 / NumberOfOccurences;
            }
        }

        private ObservableCollection<Error> errors;

        public ObservableCollection<Error> Errors
        {
            get { return errors; }
            set { errors = value; }
        }



        private int numberOfOccurences;

        public int NumberOfOccurences
        {
            get { return numberOfOccurences; }
            set
            {
                numberOfOccurences = value;
                OnPropertyChanged();
            }
        }

        private int numberOfIncorrectOccurences;

        public int NumberOfIncorrectOccurences
        {
            get { return numberOfIncorrectOccurences; }
            set
            {
                numberOfIncorrectOccurences = value;
                OnPropertyChanged();
            }
        }


        private long process;

        public long Process
        {
            get { return process; }
            set
            {
                process = value;
                OnPropertyChanged();
            }
        }


        private string note;

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }


        private string nameResult;

        public string NameResult
        {
            get { return nameResult; }
            set
            {
                nameResult = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Setting> chooseSettings;

        public ObservableCollection<Setting> ChooseSettings
        {
            get { return chooseSettings; }
            set
            {
                chooseSettings = value;
                OnPropertyChanged();
            }
        }

        private Template chooseTemplate;

        public Template ChooseTemplate
        {
            get { return chooseTemplate; }
            set { chooseTemplate = value; }
        }

        private bool analyseNow = true;

        public bool AnalyseNow
        {
            get { return analyseNow; }
            set
            {
                analyseNow = !value;
                OnPropertyChanged();
            }
        }

        private ProjectStorage projectStorage;

        public ProjectStorage ProjectStorage
        {
            get { return projectStorage; }
            set
            {
                projectStorage = value;
                OnPropertyChanged();
            }
        }


        public async void StartAnalyse(ObservableCollection<Setting> settings, Template template, ProjectStorage projectStorage)
        {
            Clear();
            ChooseSettings = settings;
            ChooseTemplate = template;
            ProjectStorage = projectStorage;
            AnalyseNow = true;
            foreach (var file in ProjectStorage.FileList)
            {
                foreach (var item in settings)
                {

                    var errorResults = Parser.Parse(item.CurrentTemplate.AllObject, File.ReadAllText(file.CurrentFile));
                    foreach (var errorString in errorResults)
                    {
                        Errors.Add(new Error() { File = file, Name = item.CurrentTemplate.Name, ErrorString = errorString });
                    }
                }
            };

            
            NumberOfIncorrectOccurences = new Random().Next(20, 35);
            NumberOfOccurences = new Random().Next(70, 100);
            AnalyseNow = false;

        }


        private void Clear()
        {
            NumberOfOccurences = 0;
            NumberOfIncorrectOccurences = 0;
            Process = 0;
        }

        private bool isSaved;

        public bool IsSaved
        {
            get { return isSaved; }
            set { isSaved = value; }
        }



        public string ChooseSettingsString
        {
            get
            {
                string answer = "";
                foreach (var item in ChooseSettings.ToList())
                {
                    answer += " " + item.CurrentTemplate.Name;
                }

                return answer;
            }

        }
        //need fix
        public RelayCommand saveResultCommand;
        public RelayCommand SaveResultCommand
        {
            get
            {
                return saveResultCommand ??
                (saveResultCommand = new RelayCommand(obj =>
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\Results\" + NameResult + ".json", JsonConvert.SerializeObject(this));
                }
                ));



            }
        }

        public RelayCommand viewSolutionCode;
        public RelayCommand ViewSolutionCode
        {
            get
            {
                return viewSolutionCode ??
                    (viewSolutionCode = new RelayCommand(obj =>
                    {

                    }
                    ));
            }
        }
    }
}
