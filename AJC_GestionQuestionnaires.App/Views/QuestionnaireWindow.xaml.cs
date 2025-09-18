using AJC_GestionQuestionnaires.App.ViewModels;
using AJC_GestionQuestionnaires.Data.Models;
using System.Windows;

namespace AJC_GestionQuestionnaires.App.Views;

public partial class QuestionnaireWindow : Window
{
    public QuestionnaireWindow(Questionnaire questionnaire)
    {
        this.DataContext = new QuestionnaireViewModel(this, questionnaire);
        InitializeComponent();
    }
}
