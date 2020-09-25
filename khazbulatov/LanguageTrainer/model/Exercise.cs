using System;
using System.Collections.Generic;
using System.Reflection;

namespace LanguageTrainer.model
{
    public abstract class Exercise
    {
        public abstract int TaskCount { get; }

        public abstract IEnumerable<string> Practice(Func<object, object> taskPresenter);
        
        public static TExercise Create<TExercise>(WordDictionary dictionary) where TExercise : Exercise, new()
        {
            Exercise exercise = new TExercise();
            exercise.Dictionary = dictionary;
            return (TExercise) exercise;
        }
        
        protected WordDictionary Dictionary { get; private set; }
    }
    
    public abstract class Exercise<TTask> : Exercise where TTask : Task
    {
        protected abstract TTask MakeTask(string word);
        protected IEnumerable<TTask> Tasks { get; }

        public Exercise()
        {
            List<TTask> tasks = new List<TTask>();
            foreach (string word in Dictionary.Sample(TaskCount)) tasks.Add(MakeTask(word));
            Tasks = tasks;
        }

        public override IEnumerable<string> Practice(Func<object, object> taskPresenter)
        {
            if (!(taskPresenter is Func<TTask, object> concreteTaskPresenter)) throw new ArgumentException();
            List<string> correctWords = new List<string>();
            foreach (TTask task in Tasks)
            {
                if (task.CheckAnswer(concreteTaskPresenter)) correctWords.Add(task.Word);
            }
            return correctWords;
        }
    }

    public class SprintExercise : Exercise<SprintTask>
    {
        public override int TaskCount => 15;

        protected override SprintTask MakeTask(string word)
        {
            Maybe<string> translation = Dictionary.LookUp(Dictionary.Sample());
            Maybe<string> rightTranslation = Dictionary.LookUp(word);

            if (!(translation is Maybe<string>.Some someTranslation)) throw new KeyNotFoundException();
            if (!(rightTranslation is Maybe<string>.Some someRightTranslation)) throw new KeyNotFoundException();
                
            return new SprintTask(word, someTranslation.Value, someRightTranslation.Value);
        }
    }

    public class TranslationExercise : Exercise<TranslationTask>
    {
        public override int TaskCount => 10;

        protected override TranslationTask MakeTask(string word)
        {
            List<TranslationTask> tasks = new List<TranslationTask>();
            Maybe<string> rightTranslation = Dictionary.LookUp(word);

            if (!(rightTranslation is Maybe<string>.Some someRightTranslation)) throw new KeyNotFoundException();

            return new TranslationTask(word, someRightTranslation.Value);
        }
    }
}
