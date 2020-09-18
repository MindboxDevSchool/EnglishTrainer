using LanguageTrainer.model;

namespace LanguageTrainer.app
{
    public class EnglishTrainer : Trainer
    {
        public EnglishTrainer() : base(new WordDictionaryFromFile(Filenames.EnRu,
            Languages.English, Languages.Russian), 3) { }
    }
}
