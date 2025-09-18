using AJC_GestionQuestionnaires.App.ViewModels;
using System.Windows;

namespace AJC_GestionQuestionnaires.App.Views;

public partial class QuestionnaireWindow : Window
{
    public QuestionnaireWindow(Data.Models.Questionnaire questionnaire)
    {
        this.DataContext = new QuestionnaireViewModel(questionnaire);
        InitializeComponent();
    }
}
