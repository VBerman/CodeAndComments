using CodeAndComments.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class Template:ObservableObject
    {
        public TemplateDetails[] TemplateDetails { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged();
            }
        }


        private string path;

        public string Path
        {
            get { return path; }
            set 
            { 
                path = value;
                ConvertFromPath();
                Name = System.IO.Path.GetFileName(value);
            }
        }

        public void ConvertFromPath()
        {
            TemplateDetails = JsonConvert.DeserializeObject<TemplateDetails[]>(File.ReadAllText(Path)); 
        }
            


    }
}
