using System;
using System.Collections.Generic;

namespace LanguageTrainer.model
{
    public class Trainer
    {
        private readonly WordDictionary _dictionary;
        private Dictionary<string, PracticedWord> _practiced;

        public Trainer(WordDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public void TakeSprintExercise(Func<SprintTask, bool> taskPresenter)
        {
            SprintExercise exercise = new SprintExercise(_dictionary);
            IEnumerable<string> correct = exercise.Practice(taskPresenter);
            foreach (string word in correct)
            {
                if (!_practiced.ContainsKey(word))
                {
                    _practiced[word] = new PracticedWord(word);
                }
                _practiced[word].Sprints++;
                if (_practiced[word].Learned)
                {
                    _dictionary.Remove(word);
                }
            }
        }
        
        public void TakeTranslationExercise(Func<TranslationTask, string> taskPresenter)
        {
            TranslationExercise exercise = new TranslationExercise(_dictionary);
            IEnumerable<string> correct = exercise.Practice(taskPresenter);
            foreach (string word in correct)
            {
                if (!_practiced.ContainsKey(word))
                {
                    _practiced[word] = new PracticedWord(word);
                }
                _practiced[word].Translations++;
                if (_practiced[word].Learned)
                {
                    _dictionary.Remove(word);
                }
            }
        }
    }
}
