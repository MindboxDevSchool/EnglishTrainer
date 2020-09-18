using System;
using System.Collections.Generic;

namespace EnglishTrainer
{
    public class TranslationExercise : IExercise
    {
        public TranslationExercise(IReadOnlyList<Word> words)
        {
            Words = words;
        }

        private IReadOnlyList<Word> Words { get; }

        public Result GetResult(List<string> userAnswers)
        {
            throw new NotImplementedException();
        }
    }
}