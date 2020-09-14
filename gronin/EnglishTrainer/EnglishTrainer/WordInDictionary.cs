namespace EnglishTrainer
{
    public class WordInDictionary
    {
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