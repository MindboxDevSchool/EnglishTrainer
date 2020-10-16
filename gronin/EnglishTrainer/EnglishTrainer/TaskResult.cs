using System.Collections.Generic;

namespace EnglishTrainer
{
    public class TaskResult
    {
        public TaskResult()
        {
            CorrectAnswers = new List<WordInDictionary>();
            IncorrectAnswers = new List<WordInDictionary>();
        }

        public List<WordInDictionary> CorrectAnswers { get; }
        
        public List<WordInDictionary> IncorrectAnswers { get; }
        
        public int AmountOfCorrect => CorrectAnswers.Count;

        public int AmountOfIncorrect => IncorrectAnswers.Count;

        public void AddCorrectAnswer(WordInDictionary newWord)
        {
            CorrectAnswers.Add(newWord);
        }
        
        public void AddIncorrectAnswer(WordInDictionary newWord)
        {
            IncorrectAnswers.Add(newWord);
        }
    }
}