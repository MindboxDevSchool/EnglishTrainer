namespace EnglishTrainer
{
    public static class ManualTranslation
    {
        public static int CountUserResults(WordsPair[] generatedWordsPairs, string[] userAnswersForManualTranslationMode)
        {
            int userScore = 0;
            for (int i = 0; i < generatedWordsPairs.Length; i++)
            {
                if (generatedWordsPairs[i]._russianWord == userAnswersForManualTranslationMode[i])
                    userScore++;
            }
            return userScore;
        }
    }
}