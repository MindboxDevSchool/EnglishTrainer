using System;

namespace EnglishTrainer
{
    public static class Sprint
    {
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