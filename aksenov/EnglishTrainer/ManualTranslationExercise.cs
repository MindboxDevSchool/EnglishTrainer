using System;

namespace EnglishTrainer
{
    public class ManualTranslationExercise: Exercise<string[]>
    {
        public ManualTranslationExercise(Vocabulary vocabulary) : base(vocabulary)
        {
        }

        public override string[] GetExerciseData()
        {
            Random random = new Random();
            
            string[] generatedWords = new string[10];
            
            var notStudiedWords = _vocabulary.GetNotStudiedWords();

            for (int i = 0; i < 10; i++)
            {
                int randomWordNumber = random.Next(0, notStudiedWords.Count);
                Word randomWord = notStudiedWords[randomWordNumber];
                generatedWords[i] = randomWord.Spelling;
            }

            return generatedWords;
        }
    }
}