using System;

namespace QuizSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionsDatabase database = new QuestionsDatabase();
            Quiz quiz = database.CreateQuiz();
            quiz.TakeQuiz();
        }
    }
}
