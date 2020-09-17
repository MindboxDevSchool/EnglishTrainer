using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public abstract class Exercise<T>
    {
        protected readonly Vocabulary _vocabulary;

        protected Exercise(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }
        
        public abstract T GetExerciseData();
        
        public ExerciseResult CheckExerciseSolution(List<Word> words)
        {
            int rightAnswers = 0;
            int wrongAnswers = 0;
            
            if (!_vocabulary.IsContains(words))
                throw new InvalidOperationException("Vocabulary doesn't contain these words. Unable to complete solution validation.");
            
            foreach (var word in words)
            {
                var processedWord = _vocabulary.Words.First(w => w.Spelling == word.Spelling);
                if (processedWord.Translation == word.Translation)
                {
                    rightAnswers++;
                    processedWord.IncreaseStudyProgress();
                }
                else
                {
                    wrongAnswers++;
                }
            }

            return new ExerciseResult(rightAnswers, wrongAnswers);
        }
    }
}