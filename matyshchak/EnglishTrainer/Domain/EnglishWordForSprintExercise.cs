using System.Collections.Generic;

namespace EnglishTrainer
{
    public class EnglishWordForSprintExercise
    {
        public EnglishWordForSprintExercise(EnglishWord wordToLearn)
        {
            WordToLearn = wordToLearn;
        }
        
        public EnglishWordForSprintExercise(EnglishWord wordToLearn, List<string> wrongTranslations)
        {
            WordToLearn = wordToLearn;
            WrongTranslations = wrongTranslations;
        }

        public EnglishWord WordToLearn { get; }
        private List<string> WrongTranslations { get; }
        public List<string> RussianTranslations => 
            WrongTranslations ?? WordToLearn.RussianTranslations;

        public bool WithWrongTranslations => WrongTranslations != null;
    }
}