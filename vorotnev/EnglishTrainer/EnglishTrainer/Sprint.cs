using System;

namespace EnglishTrainer
{
    public static class Sprint
    {
        public static int SprintProcess( WordsPairs wordsPairs)
        {
            const int numberOfWords = 15;
            var userScore = 0;
            var random = new Random();
            bool correctUserAnswer;
            for (int i = 0; i < numberOfWords; i++)
            {
                var currentWordsPair = WordsPairs.GenerateWordsPairPossiblyRandom();
                Output.OutputTextLine($"Слово {currentWordsPair._englishWord} переводится как {currentWordsPair._russianWord}?");
                var userAnswer = Input.GetUserAnswer();
                if (userAnswer == currentWordsPair.IsPairCorrect)
                    userScore++;
            }

            return userScore;
        }
    }
}