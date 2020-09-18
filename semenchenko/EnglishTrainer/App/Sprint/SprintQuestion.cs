using EnglishTrainer.Domain;

namespace EnglishTrainer.App.Sprint
{
    public class SprintQuestion : Question
    {
        public string[] OfferedTranslate { get; }

        public SprintQuestion(WordPair[] pairs, string[] offered) : base(pairs)
        {
            OfferedTranslate = offered;
        }
    }
}