using AJC_GestionQuestionnaires.Data.Models;
using Microsoft.EntityFrameworkCore;
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

    public List<Questionnaire> GetQuestionnaires() => 
        _dbContext.Questionnaires
            .Include(q => q.Questions)
            .ToList();

    public Questionnaire Add(Questionnaire questionnaire)
    {
        var dbEntity = _dbContext.Questionnaires.Add(questionnaire);
        _dbContext.SaveChanges();
        return dbEntity.Entity;
    }

    public void Delete(long id)
    {
        var questionnaire = _dbContext.Questionnaires.Find(id);

        if (questionnaire is not null)
        {
            _dbContext.Questionnaires.Remove(questionnaire);
            _dbContext.SaveChanges();
        }
    }

    public void Update(long id)
    {
        var questionnaire = _dbContext.Questionnaires.Find(id);

        if (questionnaire is not null)
        {
            _dbContext.Questionnaires.Update(questionnaire);
            _dbContext.SaveChanges();
        }
    }

}
