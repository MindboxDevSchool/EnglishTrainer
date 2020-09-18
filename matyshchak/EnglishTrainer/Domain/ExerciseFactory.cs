using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class ExerciseFactory
    {
        private IEnumerable<Word> Words { get; }
        public ExerciseFactory(IEnumerable<Word> words)
        {
            Words = words;
        }
        public TranslationExercise CreateTranslationExercise(int numberOfWords)
        {
            var wordsToTranslate = GetRandomNotLearnedWords(numberOfWords).ToList();
            return new TranslationExercise(wordsToTranslate);
        }

        public SprintExercise CreateSprintExercise(int numberOfWords, int numberOfWordsWithWrongTranslations)
        {
            var wordsForSprintExercise = GetWordsForSprintExercise(numberOfWords, numberOfWordsWithWrongTranslations);
            return new SprintExercise(wordsForSprintExercise);
        }

        private IReadOnlyList<WordForSprintExercise> GetWordsForSprintExercise(
            int numberOfWordsForExercise,
            int howManyWordsWithWrongTranslations
        )
        {
            var wordsForExercise = Words
                .Take(numberOfWordsForExercise)
                .Select(word => new WordForSprintExercise(word))
                .ToList();

            var translationsForShuffling = Words
                .TakeLast(howManyWordsWithWrongTranslations)
                .Select(word => word.Translations)
                .ToList();

            return ShuffleTranslationsToRandomWords(wordsForExercise, translationsForShuffling);

        }

        private static IReadOnlyList<WordForSprintExercise> ShuffleTranslationsToRandomWords(IReadOnlyList<WordForSprintExercise> words, IReadOnlyList<List<string>> translationsToShuffle)
        {
            if (translationsToShuffle.Count > words.Count)
                throw new ArgumentException();
            var wordsForExercise = new List<WordForSprintExercise>(words);
            for (var i = 0; i < translationsToShuffle.Count; i++)
            {
                wordsForExercise[i] = new WordForSprintExercise(wordsForExercise[i].WordToLearn, translationsToShuffle[i]);
            }

            return wordsForExercise.OrderBy(_ => Guid.NewGuid()).ToList();
        }


        public IEnumerable<Word> GetRandomNotLearnedWords(int numberOfWords)
        {
            return Words
                .Where(word => !word.IsLearned)
                .OrderBy(arg => Guid.NewGuid())
                .Take(numberOfWords);
        }
    }
}