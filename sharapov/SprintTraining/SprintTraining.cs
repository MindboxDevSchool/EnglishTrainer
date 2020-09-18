using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.SprintTraining {
    public class SprintTraining {
        private const int AmountWordsForTraining = 15;
        private const double RightWordsRatio = 0.50;
        private readonly WordsStorage _wordsStorage;
        private readonly Words _trainingWords;
        private readonly Words _rightAnswers;

        public SprintTraining(WordsStorage wordsStorage) {
            _wordsStorage = wordsStorage;
            (_rightAnswers, _trainingWords) = GenerateWordsForTraining(AmountWordsForTraining, RightWordsRatio);
        }

        //words to user (domain -> infrastructure) 
        public Words GetTrainingWords() {
            return _trainingWords;
        }

        //result from user to domain (infrastructure -> domain) 
        public SprintTrainingResult ReportAboutTrainingResult(Answers<bool> userAnswers) {
            var result = ProcessUserAnswers(userAnswers);
            var infoForUpdateProgress = result.Select(r => new ResultForUpdateStorage(r.Word, r.IsAnswerWasRight));
            _wordsStorage.UpdateProgress(infoForUpdateProgress);
            return result;
        }

        private SprintTrainingResult ProcessUserAnswers(Answers<bool> answers) {
            if (answers.Count() != AmountWordsForTraining) {
                throw new ArgumentException(
                    $"{nameof(answers)} comes wrong amount of answers. Expected {AmountWordsForTraining}");
            }

            var result = SprintTrainingResult.Create(answers, _trainingWords, _rightAnswers);
            return result;
        }

        private (Words, Words) GenerateWordsForTraining(int trainingWordsForTrainingNumber, double rightWordsRatio) {
            if (trainingWordsForTrainingNumber <= 0) {
                throw new ArgumentException($"{nameof(trainingWordsForTrainingNumber)} equal zero or less than zero");
            }

            if (rightWordsRatio < 0.0d || rightWordsRatio > 1.0d) {
                throw new ArgumentException(
                    $"{nameof(trainingWordsForTrainingNumber)} have to be between 0.0 and 1.0 inclusive");
            }

            var wordsWithRightAnswer = _wordsStorage.GenerateUnlearntWords(AmountWordsForTraining);

            var wordsWithWrongAnswers = GenerateWordsWithWrongAnswers(
                trainingWordsForTrainingNumber, rightWordsRatio, wordsWithRightAnswer);

            var wordsWithWrongAnswersShuffled = ShuffleWords(wordsWithWrongAnswers);
            return (wordsWithRightAnswer, wordsWithWrongAnswersShuffled);
        }

        private static Words ShuffleWords(Words wordsWithWrongAnswers) {
            return new Words(wordsWithWrongAnswers
                .OrderBy(x => Guid.NewGuid())
                .ToList());
        }

        private Words GenerateWordsWithWrongAnswers(int trainingWordsForTrainingNumber, double rightWordsRatio, Words
            wordsWithRightAnswer) {
            var wordsWithWrongAnswers = Words.CreateFrom(wordsWithRightAnswer);

            var amountOfWrongAnswers = CalculateAmountOfWrongAnswers(trainingWordsForTrainingNumber, rightWordsRatio);
            foreach (var unlearntWord in wordsWithRightAnswer) {
                var randomWord = _wordsStorage.GetRandomWord();
                if (randomWord.RusDefinition != unlearntWord.RusDefinition) {
                    wordsWithRightAnswer.ReplaceRusDefinition(unlearntWord.EngDefinition, randomWord.RusDefinition);
                }

                amountOfWrongAnswers--;
                if (amountOfWrongAnswers == 0) break; //TODO test it probably infinite cycle for corner cases 
            }

            return wordsWithWrongAnswers;
        }

        private static int CalculateAmountOfWrongAnswers(int trainingWordsForTrainingNumber, double rightWordsRatio) {
            return Convert.ToInt32(1.0d - rightWordsRatio * trainingWordsForTrainingNumber);
        }
    }
}