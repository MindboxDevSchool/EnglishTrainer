using System;
using System.Collections.Generic;

namespace EnglishTrainer
{
    public class Result
    {
        private List<QuestionResult> ResultWords { get; set; }
        private int NumberOfWordsGuessedCorrectly { get; set; }
        private int NumberOfWordsGuessedIncorrectly { get; set; }

        public Result(List<QuestionResult> resultWords)
        {
            this.ResultWords = resultWords;
        }
        public List<QuestionResult> GetQuestionResults()
        {
            return this.ResultWords;
        }
        public Result AppendResult(QuestionResult questionResult)
        {
            ResultWords.Add(questionResult);
            Result result = new Result(ResultWords);
            return result;
        }
        public Result CleanUpResult()
        {
            ResultWords.Clear();
            Result result = new Result(ResultWords);
            return result;
        }

        public int GetNumberOfWordsGuessedCorrectly()
        {
            NumberOfWordsGuessedCorrectly = 0;
            for (int i = 0; i < ResultWords.Count; i++)
            {
                if (ResultWords[i].IsGuessedCorrectly)
                {
                    NumberOfWordsGuessedCorrectly++;
                }
            }
            return NumberOfWordsGuessedCorrectly;
        }
        
        public int GetNumberOfWordsGuessedIncorrectly()
        {
            return ResultWords.Count - GetNumberOfWordsGuessedCorrectly();
        }
    }
}