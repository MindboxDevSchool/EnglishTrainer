namespace EnglishTrainer
{
    public class Trainer
    {
        public static void StartTrainer(int mode)
        {
            var wordsPairs = Input.GetWordsPairs();
            const int numberOfWordsForSprint = 15;
            const int numberOfWordsForManualTranslation = 10;
            var numberOfWords = 0;
            switch (mode)
            {
                case 0:
                    numberOfWords = numberOfWordsForSprint;
                    break;
                case 1:
                    numberOfWords = numberOfWordsForManualTranslation;
                    break;
            }
            int userScore = 0;
            var generatedWordsPairs = GenerateWordsPairs(mode, numberOfWordsForSprint, numberOfWordsForManualTranslation);
            Output.OutputGeneratedWordsPairs(mode, generatedWordsPairs);
            switch (mode)
            {
                case 0:
                    var userAnswersForSprintMode = Input.GetUserAnswersForSprintMode(numberOfWords);
                    userScore = Sprint.CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
                    break;
                case 1:
                    
                    var userAnswersForManualTranslationMode =
                        Input.GetUserAnswersForManualTranslationMode(numberOfWords);
                    userScore = ManualTranslation.CountUserResults(generatedWordsPairs,
                        userAnswersForManualTranslationMode);
                    break;
            }
            Output.OutputFinalResult(userScore, numberOfWords);
        }

        public static WordsPair[] GenerateWordsPairs(
            int mode, 
            int numberOfWordsForSprint, 
            int numberOfWordsForManualTranslation)
        {
            var numberOfWords = 0;
            switch (mode)
            {
                case 0:
                    numberOfWords = numberOfWordsForSprint;
                    break;
                case 1:
                    numberOfWords = numberOfWordsForManualTranslation;
                    break;
            }
            var generatedWordsPairs = new WordsPair[numberOfWords];
            for (int i = 0; i < numberOfWords; i++)
            {
                generatedWordsPairs[i] = WordsPairs.GenerateWordsPairPossiblyRandom();
            }
            
            return generatedWordsPairs;
        }
    }
}