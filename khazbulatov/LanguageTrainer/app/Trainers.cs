using LanguageTrainer.model;

namespace LanguageTrainer.app
{
    public static class Trainers
    {
        public static Trainer EnglishTrainer
        {
            get
            {
                WordDictionary dictionary = new WordDictionaryFromFile(Filenames.EnRu);
                dictionary.Load(Languages.English, Languages.Russian);
                return new Trainer(dictionary, 3);
            }
        }
    }
}
