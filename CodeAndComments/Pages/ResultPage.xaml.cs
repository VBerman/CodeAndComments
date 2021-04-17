using CodeAndComments.Classes;
using CodeAndComments.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(AnalyseClass analyse)
        {
            DataContext = analyse;
            InitializeComponent();
            
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

       

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ((AnalyseClass)DataContext).CurrentError = ((DataGrid)sender).CurrentItem as Error;
            //var error = ((DataGrid)sender).CurrentItem as Error;
            //SolutionRichTextBox
            //SolutionRichTextBox.Document..Add(new Run(error.ErrorString) { Foreground = Brushes.Red });
            //var flowDocument = new FlowDocument();
            //var paragraph = new Paragraph();
            //var block = new Run();
            //block.Text = ;

            //block.Foreground = Brushes.Navy;
            //paragraph.Inlines.Add(block);
            //flowDocument.Blocks.Add(paragraph);
        }


    }
}
