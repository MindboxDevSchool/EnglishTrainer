using System;
using System.Collections;
using System.Collections.Generic;

namespace EnglishTrainer.SprintTraining {
    public class SprintTrainingResult : IEnumerable<WordLearnInfo> {
        private readonly List<WordLearnInfo> _trainedWordsInfo;

        private SprintTrainingResult(List<WordLearnInfo> learnInfoWords) {
            _trainedWordsInfo = learnInfoWords;
        }

        public IEnumerator<WordLearnInfo> GetEnumerator() {
            return _trainedWordsInfo.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        //fabric method
        public static SprintTrainingResult Create(Answers<bool> answers, Words trainingWords,
            Words wordsWithRightAnswers) {
            var learnInfoWords = new List<WordLearnInfo>();
            //TODO how traverse 3 collection without Zip or Enumeration and then hide realization from domain ????
            using var enumeratorAnswer = answers.GetEnumerator();
            using var enumeratorTrainingWords = trainingWords.GetEnumerator();
            using var enumeratorRightAnswers = wordsWithRightAnswers.GetEnumerator();
            while (true) {
                if (enumeratorAnswer.MoveNext()) {
                    enumeratorTrainingWords.MoveNext();
                    enumeratorRightAnswers.MoveNext();
                    var answerIsRight = enumeratorAnswer.Current;
                    var trainingWord = enumeratorTrainingWords.Current;
                    var rightAnswer = enumeratorRightAnswers.Current;
                    SortingRightAndWrongAnswers(learnInfoWords, answerIsRight, trainingWord, rightAnswer);
                }
                else {
                    break; //while (true)
                }
            }

            return new SprintTrainingResult(learnInfoWords);
        }

        private static void SortingRightAndWrongAnswers(ICollection<WordLearnInfo> learnInfoWords, bool isBothMatchAnswer, Word trainingWord,
            Word rightAnswer) {
            if (trainingWord == null) {
                throw new NullReferenceException($"{nameof(trainingWord)}");
            }
            if (rightAnswer == null) {
                throw new NullReferenceException($"{nameof(rightAnswer)}");
            }

            if (IsUserWasRight(isBothMatchAnswer, trainingWord, rightAnswer)) {
                learnInfoWords.Add(new WordLearnInfo(new Word(trainingWord.RusDefinition, trainingWord.EngDefinition),
                    trainingWord.RusDefinition, true));
            }
            else {
                learnInfoWords.Add(new WordLearnInfo(new Word(trainingWord.RusDefinition, trainingWord.EngDefinition),
                    trainingWord.RusDefinition, false));
            }
        }

        private static bool IsUserWasRight(bool isBothMatchAnswer, Word trainingWord, Word rightAnswer) {
            bool AnswerAndExpectedSamePredictionRight(string trained, string expected, bool answer) =>
                trained.Equals(expected) && answer.Equals(true);

            bool AnswerAndExpectedDifferentPredictionRight(string trained, string expected, bool answer) =>
                !trained.Equals(expected) && answer.Equals(false);

            var userCouldMatchRightDefinitions = AnswerAndExpectedSamePredictionRight(trainingWord.RusDefinition,
                rightAnswer.RusDefinition, isBothMatchAnswer);
            var userCouldMatchWrongDefinitions = AnswerAndExpectedDifferentPredictionRight(trainingWord.RusDefinition,
                rightAnswer.RusDefinition, isBothMatchAnswer);

            return userCouldMatchRightDefinitions || userCouldMatchWrongDefinitions;
        }
    }
}