using System;
using System.Collections.Generic;
using System.Text;

namespace QuizSystem
{
    public class Quiz
    {
        public Quiz(Question[] questions)
        {
            Questions = questions ?? throw new ArgumentNullException(nameof(questions));
        }

        public Question[] Questions { get; }

        public int TotalPoints { get; private set; }

        public void TakeQuiz()
        {
            Console.WriteLine("Starting quiz:");

            foreach (Question q in Questions)
            {
                q.Print();
                Console.Write("Your answer=");
                string answer = Console.ReadLine();
                q.ValidateAnswer(answer);
                TotalPoints += q.Points;
            }

            Console.WriteLine($"Congrats, you've earned {TotalPoints} points!");
        }
    }
}
