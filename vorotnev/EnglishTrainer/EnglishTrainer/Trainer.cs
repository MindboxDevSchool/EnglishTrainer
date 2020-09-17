namespace EnglishTrainer
{
    public class Trainer
    {
        public static int StartTrainer(int mode)
        {
            const int numberOfWords = 15;
            int userScore = 0;
            var generatedWordsPairs = new WordsPair[numberOfWords];
            for (int i = 0; i < numberOfWords; i++)
            {
                generatedWordsPairs[i] = WordsPairs.GenerateWordsPairPossiblyRandom();
            }
            switch (mode)
            {
                case 0:
                    Output.OutputSprintGeneratedWordsPairs(generatedWordsPairs);
                    var userAnswersForSprintMode = Input.GetUserAnswersForSprintMode(numberOfWords);
                    userScore = Sprint.CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
                    break;
                case 1:
                    Output.OutputManualTranslationGeneratedWords(generatedWordsPairs);
                    var userAnswersForManualTranslationMode =
                        Input.GetUserAnswersForManualTranslationMode(numberOfWords);
                    userScore = ManualTranslation.CountUserResults(generatedWordsPairs,
                        userAnswersForManualTranslationMode);
                    break;
            }

            return userScore;
        }
    }
}