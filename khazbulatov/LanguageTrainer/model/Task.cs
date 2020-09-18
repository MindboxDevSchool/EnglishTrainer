using System;

namespace LanguageTrainer.model
{
    public abstract class Task
    {
        public string Word { get; }

        public abstract bool CheckAnswer(object answer);
        
        protected string CorrectTranslation { get; }
        
        protected Task(string word, string rightTranslation)
        {
            Word = word;
            CorrectTranslation = rightTranslation;
        }
    }
    
    public abstract class Task<TAnswer> : Task
    {
        public override bool CheckAnswer(object answer)
        {
            if (!(answer is TAnswer concreteAnswer)) throw new ArgumentException();
            return CheckConcreteAnswer(concreteAnswer);
        }
        
        protected abstract bool CheckConcreteAnswer(TAnswer answer);
        
        protected Task(string word, string rightTranslation) : base(word, rightTranslation) { }
    }

    public class SprintTask : Task<bool>
    {
        public SprintTask(string word, string translation, string rightTranslation) : base(word, rightTranslation)
        {
            Translation = translation;
        }

        protected override bool CheckConcreteAnswer(bool answer) => answer == (Translation == CorrectTranslation);
        
        private string Translation { get; }
    }

    public class TranslationTask : Task<string>
    {
        public TranslationTask(string word, string rightTranslation) : base(word, rightTranslation) { }

        protected override bool CheckConcreteAnswer(string answer) => answer.ToLower() == CorrectTranslation.ToLower();
    }
}
