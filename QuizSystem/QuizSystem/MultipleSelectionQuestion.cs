using System;
using System.Collections.Generic;

namespace QuizSystem
{
    public class MultipleSelectionQuestion : Question
    {
        public const string NoOptionAnswer = "0";

        public MultipleSelectionQuestion(
            int id,
            string description,
            Option[] options)
            : base(id, description)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public Option[] Options { get; set; }

        public int[] CorrectAnswerIndices
        {
            get
            {
                List<int> indices = new List<int>();

                for (int i = 0; i < Options.Length; i++)
                {
                    if (Options[i].IsCorrectOption)
                    {
                        indices.Add(i);
                    }
                }

                return indices.ToArray();
            }
        }

        public override void Print()
        {
            Console.WriteLine(Description);
            Console.WriteLine("Please select zero or multiple option numbers (comma separated) from the following:");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Options[i].Text}");
            }
        }

        public override void ValidateAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return;
            }

            int[] correctAnswerIndices = CorrectAnswerIndices;
            if (string.Equals(answer, NoOptionAnswer, StringComparison.OrdinalIgnoreCase) &&
                correctAnswerIndices.Length == 0)
            {
                Points = 1;
                return;
            }


            string[] parts = answer.Split(",", StringSplitOptions.RemoveEmptyEntries);
            bool allCorrect = true;
            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int partNo))
                {
                    allCorrect = false;
                    break;
                }

                bool found = false;
                for (int i = 0; i < correctAnswerIndices.Length; i++)
                {
                    if (correctAnswerIndices[i] == partNo - 1)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    allCorrect = false;
                    break;
                }
            }
            
            if (allCorrect)
            {
                Points = 1;
            }
        }
    }
}
