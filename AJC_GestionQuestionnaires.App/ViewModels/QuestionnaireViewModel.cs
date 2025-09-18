using System.Collections.ObjectModel;
using AJC_GestionQuestionnaires.Data.Models;
using AJC_GestionQuestionnaires.App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AJC_GestionQuestionnaires.App.ViewModels;

[ObservableObject]
public sealed partial class QuestionnaireViewModel
{
    public ICommand AddCommand { get; set; } = null!;
    public ICommand DeleteCommand { get; set; } = null!;
    public ICommand UpdateCommand { get; set; } = null!;

    public ObservableCollection<Question> Questions { get; set; }

    [ObservableProperty]
    private Question? selectedQuestion;
    private QuestionService questionService;

    [ObservableProperty]
    private Questionnaire questionnaire;

    [ObservableProperty]
    private bool isErrorMessageBoxEnabled = false;
    [ObservableProperty]
    private string errorMessageBoxText = String.Empty;

    public QuestionnaireViewModel(Questionnaire questionnaire)
    {
        this.questionService = new QuestionService();
        this.Questionnaire = questionnaire;
        this.Questions =  new ObservableCollection<Question>(questionnaire.Questions); // TODO : Remplacer par Questionnaire.questions
        this.AddCommand = new RelayCommand(this.AddQuestion);
        this.DeleteCommand = new RelayCommand<Question>(this.DeleteQuestion);
        this.UpdateCommand = new RelayCommand<Question>(this.UpdateQuestion);
    }

    public void AddQuestion()
    {
        var question = new Question()
        {
            Title = "Question",
            Answer = "Réponse 1",
            Answer1 = "Réponse 1",
            Answer2 = "Réponse 2",
            Answer3 = "Réponse 3",
            Answer4 = "Réponse 4",
            QuestionnaireId = Questionnaire.Id
        };
        
        
        // La valeur renvoyée est l'entitée avec l'ID généré par la DB
        var q = questionService.AddQuestion(question);
        Questionnaire.Questions.Add(q);
        Questions.Add(q);
        this.SelectedQuestion = q;
    }

    public void DeleteQuestion(Question? question)
    {
        if (question is not null)
        {
            this.questionService.RemoveQuestion(question);
            this.Questions.Remove(question);
        }
    }

    public void UpdateQuestion(Question? question)
    {
        if (question is not null)
        {
            this.questionService.UpdateQuestion(question);
        }
    }
}
