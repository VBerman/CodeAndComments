using CodeAndComments.Classes;
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
        }


        public long PercentOfIncorrectOccurences
        {
            get
            {
                return NumberOfIncorrectOccurences * 100 / NumberOfOccurences;
            }
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

        public async void StartAnalyse(ObservableCollection<Setting> settings, Template template)
        {
            Clear();
            ChooseSettings = settings;
            ChooseTemplate = template;
            AnalyseNow = true;
            await Task.Run(
                () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(50);
                        Process += 1;

                    }

                }
            );
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
                    answer +=" " + item.CurrentTemplate.Name;
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

    }
}
