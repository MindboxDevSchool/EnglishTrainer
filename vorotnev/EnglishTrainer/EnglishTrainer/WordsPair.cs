namespace EnglishTrainer
{
    public class WordsPair
    {
        public string _englishWord { get; }
        
        public string _russianWord { get; }
        
        public bool IsPairCorrect { get; }

        public WordsPair(string englishWord, string russianWord, bool isPairCorrect)
        {
            _englishWord = englishWord;
            _russianWord = russianWord;
            IsPairCorrect = isPairCorrect;
        }
    }
}