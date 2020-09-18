using System.Collections.Generic;

namespace EnglishTrainer
{
    public class WordForSprintExercise
    {
        public WordForSprintExercise(Word wordToLearn)
        {
            WordToLearn = wordToLearn;
        }
        
        public WordForSprintExercise(Word wordToLearn, List<string> wrongTranslations)
        {
            WordToLearn = wordToLearn;
            WrongTranslations = wrongTranslations;
        }

        public Word WordToLearn { get; }
        private List<string> WrongTranslations { get; }
        public List<string> Translations => 
            WrongTranslations ?? WordToLearn.Translations;
        public bool WithWrongTranslations => WrongTranslations != null;
    }
}