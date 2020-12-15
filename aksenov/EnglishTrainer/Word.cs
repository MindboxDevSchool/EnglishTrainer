namespace EnglishTrainer
{
    public class Word
    {
        public string Spelling { get; private set; }
        
        public string Translation { get; private set; }
        
        public Word(string spelling, string translation)
        {
            Spelling = spelling;
            Translation = translation;
        }
    }
}