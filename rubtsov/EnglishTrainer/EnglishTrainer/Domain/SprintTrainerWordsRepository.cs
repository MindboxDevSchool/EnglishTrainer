using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainer.Domain
{
    public class SprintTrainerWordsRepository : IWordsRepository
    {
        private Dictionary<string, string> WordsRepository { get; }
        public Dictionary<string, string> WordsToTrain { get; private set; }
        public List<string> ShuffledWordTranslations { get; private set; }
        public int WordsPerTraining { get; set; }

        private static readonly Random Randomizer = new Random();
        
        public SprintTrainerWordsRepository(string filename, int wordsPerTraining)
        {
            IWordsLoader wordsLoader = new CsvWordsLoader(filename);
            WordsRepository = wordsLoader.LoadWords;
            WordsPerTraining = wordsPerTraining;
        }

        public void SelectWordsForTrainingSession()
        {
            var wordsToTrain = new Dictionary<string, string>();
            var wordsRepositoryCount = WordsRepository.Count;
            while (wordsToTrain.Count < WordsPerTraining && wordsToTrain.Count < wordsRepositoryCount)
            {
                var randomIndex = Randomizer.Next(WordsRepository.Count);
                if (!wordsToTrain.ContainsKey(WordsRepository.ElementAt(randomIndex).Key))
                {
                    wordsToTrain
                        .Add(WordsRepository.ElementAt(randomIndex).Key,
                            WordsRepository.ElementAt(randomIndex).Value);
                }
            }
            WordsToTrain = wordsToTrain;
        }

        public void ShuffleTranslations()
        {
            ShuffledWordTranslations = WordsToTrain.Values.ToList();
            Randomizer.Shuffle(ShuffledWordTranslations);
        }

        public void RemoveLearnedWords(IEnumerable<string> correctlyAnsweredWords)
        {
            foreach (var learnedWord in correctlyAnsweredWords)
            {
                WordsRepository.Remove(learnedWord);
            }
        }
        
    }
}