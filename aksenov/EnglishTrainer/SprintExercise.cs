using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class SprintExercise: Exercise<Word[]>
    {
        public SprintExercise(Vocabulary vocabulary) : base(vocabulary)
        {
        }
        
        public override Word[] GetExerciseData()
        {
            Random random = new Random();

            Word[] generatedWords = new Word[15];

            var notStudiedWords = _vocabulary.GetNotStudiedWords();

            for (int i = 0; i < 15; i++)
            {
                int randomWordNumber = random.Next(0, notStudiedWords.Count);
                Word randomWord = notStudiedWords[randomWordNumber];

                if (random.NextDouble() < 0.5)
                {
                    generatedWords[i] = new Word(randomWord.Spelling, randomWord.Translation);
                }
                else
                {
                    randomWordNumber = random.Next(0, _vocabulary.Words.Count);
                    generatedWords[i] = new Word(randomWord.Spelling, _vocabulary.Words[randomWordNumber].Translation);
                }
            }

            return generatedWords;
        }
    }
}