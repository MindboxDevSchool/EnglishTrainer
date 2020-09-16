namespace EnglishTrainer
{
    public class WordsPair
    {
        public string _englishWord { get; }
        public string _russianWord { get; }

        public WordsPair(string englishWord, string russianWord)
        {
            _englishWord = englishWord;
            _russianWord = russianWord;
        }
    }
}