using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AJC_GestionQuestionnaires.App.ViewModels;

namespace AJC_GestionQuestionnaires.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void NewQuestionnaireButton_Clicked(object sender, RoutedEventArgs e)
        {
            var newWindow = new Questionnaire();
            newWindow.Show();
        }
    }
}