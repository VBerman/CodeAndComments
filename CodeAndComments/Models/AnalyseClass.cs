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
            Errors = new ObservableCollection<Error>();
            ErrorsFilter = new ObservableCollection<Error>();
            Comments = new ObservableCollection<Comment>();
            AnalyseResults = new ObservableCollection<AnalyseResult>();
            NotResolved = NotResolved;
        }

        private Error currentError;

        public Error CurrentError
        {
            get { return currentError; }
            set
            {
                currentError = value;
                OnPropertyChanged();
            }
        }

        public int CountComments { get => Comments.Count(); }


        private Comment currentComment;

        public Comment CurrentComment
        {
            get { return currentComment; }
            set
            {
                currentComment = value;
                OnPropertyChanged();
            }
        }


        public double PercentOfIncorrectOccurences
        {
            get
            {
                try
                {
                    return NumberOfIncorrectOccurences * 100 / (NumberOfOccurences + NumberOfIncorrectOccurences);
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }

        private bool notResolved;

        public bool NotResolved
        {
            get { return notResolved; }
            set { 
                notResolved = value;
                if (value)
                {
                    ErrorsFilter = new ObservableCollection<Error>(Errors.Where(a => a.Correctly == null).ToList());
                }
                else
                {
                    ErrorsFilter = Errors;
                }
            }
        }


        private ObservableCollection<Error> errors;

        public ObservableCollection<Error> Errors
        {
            get { return errors; }
            set {
                errors = value;
            }
        }

        private ObservableCollection<Error> errorsFilter;

        public ObservableCollection<Error> ErrorsFilter
        {
            get { return errorsFilter; }
            set { errorsFilter = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Comment> comments;

        public ObservableCollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private int numberOfNotResolved;

        public int NumberOfNotResolved
        {
            get { return numberOfNotResolved; }
            set
            {
                numberOfNotResolved = value;
                OnPropertyChanged();
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


        private int process;

        public int Process
        {
            get { return process; }
            set
            {
                process = value;
                OnPropertyChanged();
            }
        }

        private int maxProcess;

        public int MaxProcess
        {
            get { return maxProcess; }
            set { 
                maxProcess = value;
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


        public void StartAnalyse(ObservableCollection<Setting> settings, Template template, ProjectStorage projectStorage)
        {
            Clear();
            ChooseSettings = settings;
            ChooseTemplate = template;
            ProjectStorage = projectStorage;
            AnalyseNow = true;
            MaxProcess = settings.Count() * ProjectStorage.FileList.Count();
            // for optimization need swap foreaches
            foreach (var item in settings)
            {
                if (item.CurrentTemplate.Name != "Comments")
                {
                    var analyseResult = new AnalyseResult() { NameError = item.CurrentTemplate.Name };
                    foreach (var file in ProjectStorage.FileList)
                    {
                        var textFile = File.ReadAllText(file.CurrentFile);
                        var errorResults = Parser.Parse(item.CurrentTemplate.AllObject, textFile);
                        foreach (var errorString in errorResults)
                        {
                            Errors.Add(new Error() { File = file, Name = item.CurrentTemplate.Name, ErrorString = errorString });
                            Process += 1;
                        }
                        var correctResults = Parser.Parse(item.CurrentTemplate.CorrectObject, textFile);
                        analyseResult.NotResolved += errorResults.Count();
                        analyseResult.CountCorrect += correctResults.Count();
                        

                    }
                    NumberOfNotResolved += analyseResult.NotResolved;
                    NumberOfOccurences += analyseResult.CountCorrect;
                    AnalyseResults.Add(analyseResult);
                }
                else
                {
                    foreach (var file in ProjectStorage.FileList)
                    {
                        var textFile = File.ReadAllText(file.CurrentFile);
                        var commentResults = Parser.Parse(item.CurrentTemplate.AllObject, textFile);
                        foreach (var commentString in commentResults)
                        {
                            Comments.Add(new Comment() { TextComment = commentString, LocationFile = file.CurrentFile });
                            Process += 1;
                        }
                    }

                }
               




            }

            NotResolved = NotResolved;
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
                    IsSaved = true;
                    NameResult = NameResult + " " + DateTime.Now.ToString().Replace(':', '-').Replace('/', '.');
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\Results\" + NameResult + ".json", JsonConvert.SerializeObject(this));
                }
                ));



            }
        }

        public bool IsSaveBinding { get => !IsSaved; }

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
        //add mark as correctly
        //add mark as not correctly
        private RelayCommand markAsCorrectly;
        public RelayCommand MarkAsCorrectly
        {
            get
            {
                return markAsCorrectly ??
                    (markAsCorrectly = new RelayCommand(obj =>
                    {
                        if (CurrentError.Correctly == null)
                        {
                            CurrentError.Correctly = true;
                            var analyseResult = AnalyseResults.FirstOrDefault(ar => CurrentError.Name == ar.NameError);
                            analyseResult.NotResolved--;
                            analyseResult.CountCorrect++;
                            NumberOfNotResolved--;
                            NumberOfOccurences++;
                            OnPropertyChanged("PercentOfIncorrectOccurences");
                        }

                    }));
            }
        }

        private RelayCommand markAsNotCorrectly;
        public RelayCommand MarkAsNotCorrectly
        {
            get
            {
                return markAsNotCorrectly ??
                    (markAsNotCorrectly = new RelayCommand(obj =>
                    {
                        if (CurrentError.Correctly == null)
                        {
                            CurrentError.Correctly = false;
                            var analyseResult = AnalyseResults.FirstOrDefault(ar => CurrentError.Name == ar.NameError);
                            analyseResult.NotResolved--;
                            analyseResult.CountIncorrect++;
                            NumberOfNotResolved--;
                            NumberOfIncorrectOccurences++;
                            OnPropertyChanged("PercentOfIncorrectOccurences");

                        }

                    }));
            }
        }

        private RelayCommand markAllAsNotCorrectly;
        public RelayCommand MarkAllAsNotCorrectly
        {
            get
            {
                return markAllAsNotCorrectly ??
                    (markAllAsNotCorrectly = new RelayCommand(obj =>
                    {
                        foreach (var item in Errors)
                        {
                            if (item.Correctly == null)
                            {
                                item.Correctly = false;
                                var analyseResult = AnalyseResults.FirstOrDefault(ar => item.Name == ar.NameError);
                                analyseResult.NotResolved--;
                                analyseResult.CountIncorrect++;
                                NumberOfNotResolved--;
                                NumberOfIncorrectOccurences++;
                                OnPropertyChanged("PercentOfIncorrectOccurences");
                                //analyseResult.GetPercentIncorrect;
                            }
                        }


                    }));
            }
        }

        private ObservableCollection<AnalyseResult> analyseResults;

        public ObservableCollection<AnalyseResult> AnalyseResults
        {
            get { return analyseResults; }
            set { analyseResults = value; }
        }

    }
}
