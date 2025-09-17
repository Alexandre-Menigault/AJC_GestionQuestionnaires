using AJC_GestionQuestionnaires.Data.Models;
using AJC_GestionQuestionnaires.Data.AccessLayers;
using System.Collections.ObjectModel;

namespace AJC_GestionQuestionnaires.App.Services;

public class QuestionnaireService
{
    private readonly QuestionnaireRepository questionnaireRepository;

    public static ObservableCollection<Questionnaire> Questionnaires = new();

    public QuestionnaireService()
    {
        this.questionnaireRepository = new QuestionnaireRepository();
    }

    public ObservableCollection<Questionnaire> GetQuestionnaires()
        => new ObservableCollection<Questionnaire>(this.questionnaireRepository.Questionnaires);

    public static void AddQuestionaire(Questionnaire questionnaire) => Questionnaires.Add(questionnaire);

    public static void RemoveQuestionaire(Questionnaire questionnaire) => Questionnaires.Remove(questionnaire);
}
