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
    class ProjectStorage : ObservableObject
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
                loadFilesAddress(value);
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



        private void loadFilesAddress(string address)
        {
            FileList.Clear();
            foreach (var fileName in Directory.GetFiles(address))
            {
                FileList.Add(new FileStorage() { CurrentFile = address });
            }
        }

        
    }
}
