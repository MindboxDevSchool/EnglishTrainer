using System;
using System.Collections.Generic;

namespace EnglishTrainer.Domain
{
    public class SprintTrainingSession : ITrainingSession
    {
        private IWordsRepository WordsRepository { get; }
        private Func<string, string, bool> UserInteractor { get; }

        public SprintTrainingSession(IWordsRepository wordsRepository, Func<string, string, bool> userInteractor, int wordsPerTraining)
        {
            WordsRepository = wordsRepository;
            WordsRepository.WordsPerTraining = wordsPerTraining;
            UserInteractor = userInteractor;
        }

        public (int, int) StartTrainingSession()
        {
            WordsRepository.SelectWordsForTrainingSession();
            WordsRepository.ShuffleTranslations();
            var correctlyAnsweredWords = GiveWordsToUser();
            WordsRepository.RemoveLearnedWords(correctlyAnsweredWords);
            return (correctlyAnsweredWords.Count, WordsRepository.WordsToTrain.Count);
        }

        private List<string> GiveWordsToUser()
        {
            var i = 0;
            var correctlyAnsweredWords = new List<string>();
            foreach (var (wordInEnglish, correctTranslation) in WordsRepository.WordsToTrain)
            {
                var answerCorrect = AskUser(wordInEnglish, correctTranslation,
                    WordsRepository.ShuffledWordTranslations[i]);
                if (answerCorrect)
                {
                    correctlyAnsweredWords.Add(wordInEnglish);
                }
                i++;
            }
            return correctlyAnsweredWords;
        }

        private bool AskUser(string englishWord, string correctTranslation, string proposedTranslation)
        {
            var answerYes = UserInteractor(englishWord, proposedTranslation);
            return (correctTranslation == proposedTranslation && answerYes) ||
                   (correctTranslation != proposedTranslation && !answerYes);
        }
    }
}