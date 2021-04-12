using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class Template
    {
        public TemplateDetails[] TemplateDetails { get; set; }
        private string path;

        public string Path
        {
            get { return path; }
            set 
            { 
                path = value;
                ConvertFromPath();
            }
        }

        public void ConvertFromPath()
        {
            TemplateDetails = JsonConvert.DeserializeObject<TemplateDetails[]>(Path); 
        }
            


    }
}
