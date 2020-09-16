using System;
using FileHelpers;

namespace EnglishTrainer
{
    [DelimitedRecord(",")]
    [IgnoreFirst()]
    public class WordInDictionary
    {
        public WordInDictionary()
        {
        }

        public WordInDictionary(string english, string russian)
        {
            English = english ?? throw new ArgumentNullException(nameof(english));
            Russian = russian ?? throw new ArgumentNullException(nameof(russian));
            AmountOfSuccsessfulTranslations = 0;
        }

        public string English { get; private set; }
        public string Russian { get; private set; }
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