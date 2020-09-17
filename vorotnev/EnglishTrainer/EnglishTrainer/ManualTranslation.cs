namespace EnglishTrainer
{
    public static class ManualTranslation
    {
        public static int CountUserResults(WordsPair[] generatedWordsPairs, string[] userAnswersForSprintMode)
        {
            int userScore = 0;
            for (int i = 0; i < generatedWordsPairs.Length; i++)
            {
                if (generatedWordsPairs[i]._englishWord == userAnswersForSprintMode[i])
                    userScore++;
            }
            return userScore;
        }
    }
}