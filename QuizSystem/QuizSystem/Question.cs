using System;
using System.Collections.Generic;
using System.Text;

namespace QuizSystem
{
    public abstract class Question
    {
        public Question(int id, string description)
        {
            Id = id;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the question text / description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the points taken for this question.
        /// </summary>
        public int Points { get; protected set; }

        /// <summary>
        /// Makes the question print its text and options.
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Validates the answer and sets the current question points.
        /// </summary>
        /// <param name="answer">The answer received from the user.</param>
        public abstract void ValidateAnswer(string answer);
    }
}
