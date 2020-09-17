using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class SprintExercise
    {
        private readonly IEnglishWordsRepository _englishWordsRepository;
        private readonly Random _random = new Random();

        public SprintExercise(IEnglishWordsRepository englishWordsRepository)
        {
            _englishWordsRepository = englishWordsRepository;
        }

        public IReadOnlyList<EnglishWordForSprintExercise> GetWords(int numberOfWordsForExercise, int howManyWordsWithWrongTranslations)
        {
            var words = _englishWordsRepository
                .GetRandomNotLearnedWords(numberOfWordsForExercise + howManyWordsWithWrongTranslations)
                .ToList();
            
            var wordsForExercise = words
                .Take(numberOfWordsForExercise)
                .Select(word => new EnglishWordForSprintExercise(word))
                .ToList();

            var translationsForShuffling = words
                .TakeLast(howManyWordsWithWrongTranslations)
                .Select(word => word.RussianTranslations)
                .ToList();

            return ShuffleTranslationsToRandomWords(wordsForExercise, translationsForShuffling);

        }

        private IReadOnlyList<EnglishWordForSprintExercise> ShuffleTranslationsToRandomWords(IReadOnlyList<EnglishWordForSprintExercise> words, IReadOnlyList<List<string>> translationsToShuffle)
        {
            if (translationsToShuffle.Count > words.Count)
                throw new ArgumentException();
            var wordsForExercise = new List<EnglishWordForSprintExercise>(words);
            for (var i = 0; i < translationsToShuffle.Count; i++)
            {
                wordsForExercise[i] = new EnglishWordForSprintExercise(wordsForExercise[i].WordToLearn, translationsToShuffle[i]);
            }

            return wordsForExercise.OrderBy(_ => Guid.NewGuid()).ToList();
        }
    }
}