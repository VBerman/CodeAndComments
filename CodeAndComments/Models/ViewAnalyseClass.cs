using CodeAndComments.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeAndComments.Models
{
    public class ViewAnalyseClass : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string filePath;

        public string FilePath
        {
            get => filePath;
            set { filePath = value; }
        }

        private AnalyseClass analyse;

        public AnalyseClass Analyse
        {
            get
            {
                if (analyse == null)
                {
                    analyse = JsonConvert.DeserializeObject<AnalyseClass>(File.ReadAllText(FilePath));
                    return analyse;
                }
                else
                {
                    return analyse;
                }
                
            }
        }
    }
}
