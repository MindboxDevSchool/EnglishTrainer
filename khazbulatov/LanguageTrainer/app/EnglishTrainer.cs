using LanguageTrainer.model;

namespace LanguageTrainer.app
{
    public class EnglishTrainer : Trainer
    {
        public EnglishTrainer() : base(new WordDictionaryFromFile("en_ru.csv",
            Languages.English, Languages.Russian))
        {
            
        }
    }
}
