using System;

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
                int randomWordIndex = random.Next(0, notStudiedWords.Count);
                Word randomWord = notStudiedWords[randomWordIndex];

                if (random.NextDouble() < 0.5)
                {
                    generatedWords[i] = new Word(randomWord.Spelling, randomWord.Translation);
                }
                else
                {
                    randomWordIndex = random.Next(0, _vocabulary.Words.Count);
                    generatedWords[i] = new Word(randomWord.Spelling, _vocabulary.Words[randomWordIndex].Translation);
                }
            }

            return generatedWords;
        }
    }
}