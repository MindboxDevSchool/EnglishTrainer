﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public abstract class Exercise<T>
    {
        protected Vocabulary _vocabulary;

        protected Exercise(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }
        
        public abstract T GetExerciseData();
        
        public ExerciseResult CheckSolution(List<Word> words)
        {
            int rightAnswers = 0;
            int wrongAnswers = 0;
            
            if (!_vocabulary.IsContains(words))
                throw new InvalidOperationException();
            
            foreach (var word in words)
            {
                var processedWord = _vocabulary.Words.First(w => w.Spelling == word.Spelling);
                if (processedWord.Translation == word.Translation)
                {
                    rightAnswers++;
                    processedWord.IncreaseCorrectTranslationsNumber();
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