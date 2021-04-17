using CodeAndComments.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndComments.Models
{
    public class ProjectStorage : ObservableObject
    {
        public ProjectStorage()
        {
            FileList = new ObservableCollection<FileStorage>();
        }

        private string address;

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
                LoadFilesAddress(value);
            }
        }

        private ObservableCollection<FileStorage> fileList;

        public ObservableCollection<FileStorage> FileList
        {
            get { return fileList; }
            set 
            { 
                fileList = value;
                OnPropertyChanged(nameof(FileList));
            }
        }



        private void LoadFilesAddress(string address)
        {
            FileList.Clear();
            foreach (var fileName in Directory.GetFiles(address, "*.cs", SearchOption.AllDirectories))
            {
                //need remove and fix choose files window

                FileList.Add(new FileStorage() { CurrentFile = fileName });
            
                
            }
        }

        
    }
}
