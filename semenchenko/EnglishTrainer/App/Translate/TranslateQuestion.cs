using EnglishTrainer.Domain;

namespace EnglishTrainer.App.Translate
{
    public class TranslateQuestion : Question
    {
        public TranslateQuestion(WordPair[] pairs) : base(pairs)
        {
            
        }
    }
}