using AJC_GestionQuestionnaires.App.Services;
using AJC_GestionQuestionnaires.App.ViewModels.Abstractions;
using AJC_GestionQuestionnaires.App.Views;
using AJC_GestionQuestionnaires.Data.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


namespace AJC_GestionQuestionnaires.App.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject, INotifyCollectionChanged
{
    public ICommand AddQuestionnaireCommand{ get; set; } = null!;
    public ICommand UpdateQuestionnaireCommand { get; set; } = null!;
    public ICommand DeleteQuestionnaireCommand { get; set; } = null!;

    private Window window;

    [ObservableProperty]
    private ObservableCollection<Questionnaire> questionnaires;
    private QuestionnaireService questionnaireService;

    [ObservableProperty]
    private Questionnaire? selectedQuestionnaire;

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public MainWindowViewModel(Window window)
    {
        this.window = window;
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = questionnaireService.GetQuestionnaires();
        this.AddQuestionnaireCommand = new RelayCommand(this.AddQuestionnaire);
        this.UpdateQuestionnaireCommand = new RelayCommand<Questionnaire>(this.UpdateQuestionnaire);
        this.DeleteQuestionnaireCommand = new RelayCommand<Questionnaire>(this.DeleteQuestionnaire);
    }

    public void AddQuestionnaire()
    {
        var questionnaire = new Questionnaire()
        {
            Title = "Nouveau questionnaire",
            Questions = []
        };

        var q = this.questionnaireService.AddQuestionnaire(questionnaire);
        Questionnaires.Add(q);
        this.SelectedQuestionnaire = questionnaire;
    }

    public void UpdateQuestionnaire(Questionnaire? questionnaire)
    {
        if(questionnaire is not null)
        {
            var newWindow = new QuestionnaireWindow(questionnaire);
            newWindow.Owner = Window.GetWindow(this.window);
            newWindow.Show();
            newWindow.Closed += NewWindow_Closed;
        }
    }

    private void NewWindow_Closed(object? sender, EventArgs e)
    {
        var qService = new QuestionnaireService();
        if (SelectedQuestionnaire is not null)
        {
            SelectedQuestionnaire.Questions = null;
            qService.UpdateQuestionnaire(SelectedQuestionnaire);
        }
        var temp = qService.GetQuestionnaires();
        this.Questionnaires = temp;
    }

    public void DeleteQuestionnaire(Questionnaire? questionnaire)
    {
        if (questionnaire is not null)
        {
            this.questionnaireService.RemoveQuestionnaire(questionnaire);
            this.Questionnaires.Remove(questionnaire);
        }
    }
}
