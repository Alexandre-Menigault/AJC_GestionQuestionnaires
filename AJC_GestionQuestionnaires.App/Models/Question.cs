namespace AJC_GestionQuestionnaires.App.Models;

public sealed class Question
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Answer1 { get; set; } = null!;
    public string Answer2 { get; set; } = null!;
    public string? Answer3 { get; set; }
    public string? Answer4 { get; set; }

    public string Answer { get; set; } = null!;
}

