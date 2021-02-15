using System;
using System.Collections.Generic;
using System.Text;

namespace QuizSystem
{
    public class Option
    {
        public Option(string text, bool isCorrectOne = false)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            IsCorrectOption = isCorrectOne;
        }

        public string Text { get; }

        public bool IsCorrectOption { get; }
    }
}
