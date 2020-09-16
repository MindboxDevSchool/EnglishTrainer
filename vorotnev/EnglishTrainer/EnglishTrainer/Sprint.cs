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
                var isWordPairCorrect = random.Next(2) > 0;
                if (isWordPairCorrect)
                    correctUserAnswer = true;
                else
                    correctUserAnswer = false;
                var currentWordsPair = WordsPairs.GetRandomWordsPair(isWordPairCorrect);
                Output.OutputTextLine($"Слово {currentWordsPair._englishWord} переводится как {currentWordsPair._russianWord}?");
                var userAnswer = Input.GetUserAnswer();
                if (userAnswer == correctUserAnswer)
                    userScore++;
            }

            return userScore;
        }
    }
}