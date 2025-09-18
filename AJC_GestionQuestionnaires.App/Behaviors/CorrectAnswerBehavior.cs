using AJC_GestionQuestionnaires.App.ViewModels;
using AJC_GestionQuestionnaires.App.Views;
using AJC_GestionQuestionnaires.Data.Models;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

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
            var text = question.Answer;
            if (txtBox.Name.Equals("txtBoxAnswer"))
            {
                text = txtBox.Text;
            }
            var correct = IsCorrect(text, context.window);
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                context.ErrorMessageBoxText = "La réponse ne peut pas être vide";
                context.IsErrorMessageBoxEnabled = true;
            }
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

        private bool IsCorrect(string text, QuestionnaireWindow window)
        {
            var questions = new List<string>([window.txtBox1.Text, window.txtBox2.Text, window.txtBox3.Text, window.txtBox4.Text]);
            return questions.Contains(text);
        }
    }
}
