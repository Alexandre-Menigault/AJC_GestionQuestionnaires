using AJC_GestionQuestionnaires.Data.Models;
using AJC_GestionQuestionnaires.App.ViewModels;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AJC_GestionQuestionnaires.App.Behaviors
{
    public class CorrectAnswerBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            var txtBox = this.AssociatedObject as TextBox;
            txtBox.TextChanged += OnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var txtBox = this.AssociatedObject as TextBox;
            txtBox.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = this.AssociatedObject as TextBox;
            var context = ((QuestionnaireViewModel)txtBox.DataContext);
            Question? question = context.SelectedQuestion;

            if (question is null) return;
            var correct = IsCorrect(txtBox.Text, question);
            if (!correct)
            {
                context.ErrorMessageBoxText = "La réponse entrée n'existe pas parmis les propositions";
                context.IsErrorMessageBoxEnabled = true;
            } else
            {
                context.ErrorMessageBoxText = "";
                context.IsErrorMessageBoxEnabled = false;
            }
        }

        private bool IsCorrect(string text, Question question) 
        {
            var questions = new List<string>([question.Answer1, question.Answer2, question.Answer3!, question.Answer4!]);
            return questions.Contains(text);
        }
    }
}
