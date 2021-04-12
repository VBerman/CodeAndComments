using CodeAndComments.Interfaces;
using CodeAndComments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Classes
{
    public class Setting : ObservableObject
    {
        private bool isUsage;

        public bool IsUsage
        {
            get { return isUsage; }
            set 
            { 
                isUsage = value;
                OnPropertyChanged();
            }
        }

        private TemplateDetails currentTemplate;

        public TemplateDetails CurrentTemplate
        {
            get { return currentTemplate; }
            set { currentTemplate = value; }
        }



        public Setting(TemplateDetails templateDetails)
        {
            CurrentTemplate = templateDetails;
        }

        //public string ReturnRegularExpression()
        //{

        //}


    }
}
