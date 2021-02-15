using System;

namespace QuizSystem
{
    public class SingleSelectionQuestion : Question
    {
        public const string NoOptionAnswer = "0";
        public const int NoOptionIndex = -1;

        public SingleSelectionQuestion(
            int id, 
            string description,
            Option[] options)
            : base (id, description)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            int countCorrectOptions = 0;
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].IsCorrectOption)
                {
                    countCorrectOptions++;
                }
            }

            if (countCorrectOptions > 1)
            {
                throw new ArgumentException(nameof(options), "Only max 1 option can be the correct one");
            }

            Options = options;
        }

        public Option[] Options { get; }

        public int CorrectAnswerIndex
        {
            get
            {
                for (int i = 0; i < Options.Length; i++)
                {
                    if (Options[i].IsCorrectOption)
                    {
                        return i;
                    }
                }

                return NoOptionIndex;
            }
        }

        public override void Print()
        {
            Console.WriteLine(Description);
            Console.WriteLine("Please select zero or a single option number from the following:");
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

            if (!int.TryParse(answer, out int answerOptionNumber))
            {
                return;
            }

            // nr = index + 1
            // no options => nr = 0 => index = -1
            if (answerOptionNumber - 1 == CorrectAnswerIndex)
            {
                Points = 1;
            }
        }
    }
}
