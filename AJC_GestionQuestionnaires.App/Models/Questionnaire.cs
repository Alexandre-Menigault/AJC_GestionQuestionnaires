namespace AJC_GestionQuestionnaires.App.Models
{
    public sealed class Questionnaire
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public List<Question> Questions { get; set; } = null!;

    }
}
