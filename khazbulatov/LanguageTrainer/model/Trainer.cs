using System;
using System.Collections.Generic;

namespace LanguageTrainer.model
{
    public class Trainer
    {
        private WordDictionary Words { get; }
        private Dictionary<string, int> PracticedWords { get; }
        private int TimesPracticedToLearn { get; }

        public Trainer(WordDictionary words, int timesPracticedToLearn)
        {
            Words = words;
            PracticedWords = new Dictionary<string, int>();
            TimesPracticedToLearn = timesPracticedToLearn;
        }

        public void Practice<TExercise>(Func<object, object> taskPresenter) where TExercise : Exercise, new()
        {
            TExercise exercise = Exercise.Create<TExercise>(Words);
            IEnumerable<string> correctWords = exercise.Practice(taskPresenter);
            foreach (string word in correctWords)
            {
                int timesPracticed = PracticedWords.GetValueOrDefault(word) + 1;
                if (timesPracticed >= TimesPracticedToLearn) Words.Remove(word);
                PracticedWords[word] = timesPracticed;
            }
        }
    }
}
