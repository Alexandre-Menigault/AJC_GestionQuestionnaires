using AJC_GestionQuestionnaires.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AJC_GestionQuestionnaires.Data.AccessLayers;


public sealed class QuestionRepository
{
    internal readonly QuestionnaireManagerDbContext dbContext;
    public QuestionRepository()
    {
        this.dbContext = new QuestionnaireManagerDbContext();    
    }

    public List<Question> GetQuestions() => 
        dbContext.Questions.ToList();
    public Question Add(Question question)
    {
        var dbEntity = dbContext.Questions.Add(question);
        dbContext.SaveChanges();
        return dbEntity.Entity;
    }

    public void Delete(long id)
    {
        var question = dbContext.Questions.Find(id);
        if (question is not null)
        {
            dbContext.Questions.Remove(question);
            dbContext.SaveChanges();
        }
    }

    public void Update(long id)
    {
        var question = dbContext.Questions.Find(id);
        if (question is not null)
        {
            dbContext.Questions.Update(question);
            dbContext.SaveChanges();
        }
    }
}
