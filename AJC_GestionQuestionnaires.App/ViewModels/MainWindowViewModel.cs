using AJC_GestionQuestionnaires.App.ViewModels.Abstractions;
using AJC_GestionQuestionnaires.App.Models;
using AJC_GestionQuestionnaires.App.Services;
using System.Collections.ObjectModel;

namespace AJC_GestionQuestionnaires.App.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel
{
    public ObservableCollection<Questionnaire> Questionnaires { get; set; } = new();
    private QuestionnaireService questionnaireService;

    public MainWindowViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        //this.Questionnaires = questionnaireService.Questionnaires;
    }

}
