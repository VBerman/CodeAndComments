using CodeAndComments.Classes;
using CodeAndComments.Models;
using CodeAndComments.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeAndComments.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResultPage(ViewModel.Instance.Analyse));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Instance.CurrentAnalyseResult == null)
            {
                MessageBox.Show("Choose analyse result");
            }
            else
            {
                NavigationService.Navigate(new ResultPage(ViewModel.Instance.CurrentAnalyseResult.Analyse));
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Templates\NewTemplate.json", "");
            Process.Start("notepad.exe", Directory.GetCurrentDirectory() + @"\Templates\NewTemplate.json");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", ViewModel.Instance.Template.Path);
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var chooseFilesWindow = new ChooseFilesWindow((ApplicationViewModel)DataContext);
        //    chooseFilesWindow.Show();

        //}
    }
}
