using System.Collections.Generic;

namespace LanguageTrainer.model
{
    public abstract class Exercise
    {
        public abstract int TaskCount { get; }

        public abstract IEnumerable<string> Practice();
        
        public static TExercise Create<TExercise>(WordDictionary dictionary) where TExercise : Exercise, new()
        {
            Exercise exercise = new TExercise();
            return (TExercise) exercise;
        }
    }
    
    public abstract class Exercise<TTask> : Exercise where TTask : Task, new()
    {
        protected abstract IEnumerable<TTask> Tasks { get; }
        
        public override IEnumerable<string> Practice()
        {
            List<string> correctWords = new List<string>();
            foreach (TTask task in Tasks)
            {
                task.CheckAnswer();
            }
            return correctWords;
        }
    }

    public class SprintExercise : Exercise<SprintTask>
    {
        public override int TaskCount => 15;
    }
    
    public class TranslationExercise : Exercise<TranslationTask>
    {
        public override int TaskCount => 10;
    }
}
