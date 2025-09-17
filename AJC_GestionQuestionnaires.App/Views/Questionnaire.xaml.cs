using AJC_GestionQuestionnaires.App.ViewModels;
using System.Windows;

namespace AJC_GestionQuestionnaires.App.Views;

public partial class Questionnaire : Window
{
    public Questionnaire()
    {
        this.DataContext = new QuestionnaireViewModel();
        InitializeComponent();
    }
}
