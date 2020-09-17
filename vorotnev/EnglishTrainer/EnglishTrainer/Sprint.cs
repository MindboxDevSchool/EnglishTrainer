using System;

namespace EnglishTrainer
{
    public static class Sprint
    {
        public static int SprintProcess(WordsPairs wordsPairs)
        {
            const int numberOfWords = 15;
            int userScore;
            var generatedWordsPairs = new WordsPair[numberOfWords];
            for (int i = 0; i < numberOfWords; i++)
            {
                generatedWordsPairs[i] = WordsPairs.GenerateWordsPairPossiblyRandom();
            }
            Output.OutputGeneratedWordsPairs(generatedWordsPairs);
            var userAnswersForSprintMode = Input.GetUserAnswersForSprintMode(numberOfWords);
            userScore = CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
            return userScore;
        }

        public static int CountUserResults(WordsPair[] generatedWordsPairs, bool[] userAnswersForSprintMode)
        {
            int userScore = 0;
            for (int i = 0; i < generatedWordsPairs.Length; i++)
            {
                if (generatedWordsPairs[i].IsPairCorrect == userAnswersForSprintMode[i])
                    userScore++;
            }

            return userScore;
        }
    }
}