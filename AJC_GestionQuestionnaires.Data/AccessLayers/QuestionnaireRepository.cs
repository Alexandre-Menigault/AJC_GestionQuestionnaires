using AJC_GestionQuestionnaires.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJC_GestionQuestionnaires.Data.AccessLayers;

public class QuestionnaireRepository
{
    private readonly QuestionnaireManagerDbContext _dbContext;

    public QuestionnaireRepository()
    {
        this._dbContext = new QuestionnaireManagerDbContext();
    }

    public List<Questionnaire> Questionnaires => 
        _dbContext.Questionnaires.ToList();

    public void Add(Questionnaire questionnaire)
    {
        _dbContext.Questionnaires.Add(questionnaire);
        _dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var questionnaire = _dbContext.Questionnaires.Find(id);

        if(questionnaire is not null)
        {
            _dbContext.Questionnaires.Remove(questionnaire);
            _dbContext.SaveChanges();
        }
    }

}
