using AJC_GestionQuestionnaires.Data.Models;
using AJC_GestionQuestionnaires.Data.AccessLayers;
using System.Collections.ObjectModel;

namespace AJC_GestionQuestionnaires.App.Services;

public class QuestionnaireService
{
    private readonly QuestionnaireRepository questionnaireRepository;

    public QuestionnaireService()
    {
        this.questionnaireRepository = new QuestionnaireRepository();
    }

    public ObservableCollection<Questionnaire> GetQuestionnaires()
        => new ObservableCollection<Questionnaire>(questionnaireRepository.GetQuestionnaires());

    public Questionnaire AddQuestionnaire(Questionnaire questionnaire) => questionnaireRepository.Add(questionnaire);

    public void RemoveQuestionnaire(Questionnaire questionnaire) => questionnaireRepository.Delete(questionnaire.Id);

    public void UpdateQuestionnaire(Questionnaire questionnaire) => questionnaireRepository.Update(questionnaire.Id);
}
