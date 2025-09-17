using AJC_GestionQuestionnaires.Data.Models;
using AJC_GestionQuestionnaires.Data.AccessLayers;
using System.Collections.ObjectModel;

namespace AJC_GestionQuestionnaires.App.Services;

public class QuestionService
{

    private readonly QuestionRepository questionRepository;

    public QuestionService()
    {
        this.questionRepository = new QuestionRepository();
    }

    public ObservableCollection<Question> GetQuestions() => 
        new ObservableCollection<Question>(questionRepository.GetQuestions());

    public Question AddQuestion(Question question) => questionRepository.Add(question);

    public void RemoveQuestion(Question question) => questionRepository.Delete(question.Id);

    public void UpdateQuestion(Question question) => questionRepository.Update(question.Id);
}
