using System;

namespace EnglishTrainer
{
    public class WordInDictionary
    {
        public WordInDictionary(string english, string russian)
        {
            English = english ?? throw new ArgumentNullException(nameof(english));
            Russian = russian ?? throw new ArgumentNullException(nameof(russian));
            AmountOfSuccsessfulTranslations = 0;
        }

        public string English { get; }
        public string Russian { get; }
        public int AmountOfSuccsessfulTranslations { get; private set; }

        public void IncrementAmountOfSuccsessfulTranslations()
        {
            AmountOfSuccsessfulTranslations++;
        }
        
        public void ResetAmountOfSuccsessfulTranslations()
        {
            AmountOfSuccsessfulTranslations = 0;
        }
    }
}