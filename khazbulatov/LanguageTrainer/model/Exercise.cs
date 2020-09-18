using System;
using System.Collections.Generic;

namespace LanguageTrainer.model
{
    public abstract class Exercise
    {
        protected readonly WordDictionary Dictionary;

        protected Exercise(WordDictionary dictionary)
        {
            Dictionary = dictionary;
        }
        
        protected abstract int TaskCount { get; }
    }
    
    public abstract class Exercise<TTask> : Exercise
    {
        protected abstract IEnumerable<TTask> Tasks { get; }

        protected Exercise(WordDictionary dictionary) : base(dictionary) { }
    }
    
    public class SprintExercise : Exercise<SprintTask>
    {
        protected override int TaskCount => 15;

        protected override IEnumerable<SprintTask> Tasks { get; }

        private SprintTask MakeTask(string word)
        {
            Maybe<string> translation = Dictionary.LookUp(Dictionary.Sample());
            Maybe<string> rightTranslation = Dictionary.LookUp(word);
                
            if (!(translation is Maybe<string>.Some someTranslation)) throw new KeyNotFoundException();
            if (!(rightTranslation is Maybe<string>.Some someRightTranslation)) throw new KeyNotFoundException();
                
            return new SprintTask(word, someTranslation.Value, someRightTranslation.Value);
        }

        public SprintExercise(WordDictionary words) : base(words)
        {
            List<SprintTask> tasks = new List<SprintTask>();
            foreach (string word in Dictionary.Sample(TaskCount))
            {
                tasks.Add(MakeTask(word));
            }
            Tasks = tasks;
        }
        
        public IEnumerable<string> Practice(Func<SprintTask, bool> taskPresenter)
        {
            List<string> correct = new List<string>();
            foreach (SprintTask task in Tasks)
            {
                bool answer = taskPresenter.Invoke(task);
                if (task.CheckAnswer(answer)) correct.Add(task.Word);
            }
            return correct;
        }
    }
    
    public class TranslationExercise : Exercise<TranslationTask>
    {
        protected override int TaskCount => 10;
        protected override IEnumerable<TranslationTask> Tasks { get; }
        
        private TranslationTask MakeTask(string word)
        {
            Maybe<string> rightTranslation = Dictionary.LookUp(word);
            
            if (!(rightTranslation is Maybe<string>.Some someRightTranslation)) throw new KeyNotFoundException();
                
            return new TranslationTask(word, someRightTranslation.Value);
        }

        public TranslationExercise(WordDictionary words) : base(words)
        {
            List<TranslationTask> tasks = new List<TranslationTask>();
            foreach (string word in Dictionary.Sample(TaskCount))
            {
                tasks.Add(MakeTask(word));
            }
            Tasks = tasks;
        }
        
        public IEnumerable<string> Practice(Func<TranslationTask, string> taskPresenter)
        {
            List<string> correct = new List<string>();
            foreach (TranslationTask task in Tasks)
            {
                string answer = taskPresenter.Invoke(task);
                if (task.CheckAnswer(answer)) correct.Add(task.Word);
            }
            return correct;
        }
    }
}
