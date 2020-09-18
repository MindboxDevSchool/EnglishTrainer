using System;

namespace LanguageTrainer.model
{
    public abstract class Task<TAnswer>
    {
        protected string _correctTranslation;
        
        protected Task(string word, string rightTranslation)
        {
            Word = word;
            _correctTranslation = rightTranslation;
        }
        
        public static Type AnswerType = typeof(TAnswer); 
        public string Word { get; }
        
        public abstract bool CheckAnswer(TAnswer answer);
    }

    public class SprintTask : Task<bool>
    {
        private string _translation;

        public SprintTask(string word, string translation, string rightTranslation) : base(word, rightTranslation)
        {
            _translation = translation;
        }

        public override bool CheckAnswer(bool answer)
        {
            return answer == (_translation == _correctTranslation);
        }
    }

    public class TranslationTask : Task<string>
    {
        public TranslationTask(string word, string rightTranslation) : base(word, rightTranslation) { }

        public override bool CheckAnswer(string answer)
        {
            return answer.ToLower() == _correctTranslation.ToLower();
        }
    }
}
