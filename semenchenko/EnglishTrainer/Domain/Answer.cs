using System;
using System.Collections.Generic;

namespace EnglishTrainer.Domain
{
    // depending on excercise answer will be different:
    // if sprint - accept or reject offered translation (true or false); Answer<bool>
    // if translation - given translation on native language; Answer<string>
    public class Answer<T>
    {
        public List<bool> IsCorrect { get; }
        public List<T> SubAnswers { get; private set; }
        private readonly int _length;

        public Answer(int length)
        {
            _length = length;
            IsCorrect = new List<bool>();
            SubAnswers = new List<T>();
        }
        
        public void PushBackAnswer(T subanswer)
        {
            if (SubAnswers.Count >= _length)
            {
                throw new IndexOutOfRangeException();
            }
            SubAnswers.Add(subanswer);
        }

        public void SubmitAnswers(T[] subanswers)
        {
            if (subanswers.Length >= _length)
            {
                throw new IndexOutOfRangeException();
            }
            SubAnswers = new List<T>(subanswers);
        }

        public void MarkSubAnswer(bool answer)
        {
            if (IsCorrect.Count >= _length)
            {
                throw new IndexOutOfRangeException();
            }
            IsCorrect.Add(answer);
        }
    }
}