namespace QuizSystem
{
    public class QuestionsDatabase
    {
        public Quiz CreateQuiz()
        {
            return new Quiz(
                new Question[]
                {
                    new SingleSelectionQuestion(
                        1, 
                        "Which of these are vegetables?",
                        new Option[]
                        {
                            new Option("Banana"),
                            new Option("Apple"),
                            new Option("Tomato")
                        }),

                    new SingleSelectionQuestion(
                        2,
                        "Which of these have no curves?",
                        new Option[]
                        {
                            new Option("Cylinder"),
                            new Option("Ball"),
                            new Option("Pyramid", true),
                        }),

                    new MultipleSelectionQuestion(
                        3,
                        "Select all fruits.",
                        new Option[]
                        {
                            new Option("Carrot"),
                            new Option("Cherry", true),
                            new Option("Tomato", true)
                        })
                });
        }
    }
}
