using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.SprintTraining {
    public class SprintTrainingResult : IEnumerable<WordLearnInfo> {
        private readonly List<WordLearnInfo> _trainedWordsInfo;
        
        public double Count => _trainedWordsInfo.Count;

        public IEnumerator<WordLearnInfo> GetEnumerator() {
            return _trainedWordsInfo.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int AmountHit {
            get {
                return  _trainedWordsInfo.Count(x => x.UserMakeRightChoice.Equals(true));
            }
        }
        
        public int AmountMiss {
            get {
                return  _trainedWordsInfo.Count(x => x.UserMakeRightChoice.Equals(false));
            }
        }

        public SprintTrainingResult(UserAnswers<bool> userAnswers, Words trainingWords, Words wordsWithRightAnswers) {
            _trainedWordsInfo = new List<WordLearnInfo>();
            //TODO how traverse 3 collection without triple Zip or Enumeration and then hide realization from domain ????
            using var enumeratorAnswer = userAnswers.GetEnumerator();
            using var enumeratorTrainingWords = trainingWords.GetEnumerator();
            using var enumeratorRightAnswers = wordsWithRightAnswers.GetEnumerator();
            while (true) {
                if (enumeratorAnswer.MoveNext()) {
                    enumeratorTrainingWords.MoveNext();
                    enumeratorRightAnswers.MoveNext();
                    var userProposedThatAnswerIsRight = enumeratorAnswer.Current;
                    var rusTrainingDefinition = enumeratorTrainingWords.Current?.RusDefinition;
                    var rusRightDefinition = enumeratorRightAnswers.Current?.RusDefinition;
                    var engRightDefinition = enumeratorRightAnswers.Current?.EngDefinition;
                    if (IsUserWasRight(userProposedThatAnswerIsRight, rusTrainingDefinition, rusRightDefinition)) {
                        _trainedWordsInfo.Add(new WordLearnInfo(rusRightDefinition, engRightDefinition,
                            rusTrainingDefinition, true));
                    }
                    else {
                        _trainedWordsInfo.Add(new WordLearnInfo(rusRightDefinition, engRightDefinition,
                            rusTrainingDefinition, false));
                    }
                }
                else {
                    break; //while (true)
                }
            }
        }
      
        private static bool IsUserWasRight(bool userProposedAnswer, string trainingWord, string rightAnswer) {
            bool AnswerAndExpectedSamePredictionRight(string trained, string expected, bool answer) =>
                trained.Equals(expected) && answer.Equals(true);

            bool AnswerAndExpectedDifferentPredictionRight(string trained, string expected, bool answer) =>
                !trained.Equals(expected) && answer.Equals(false);

            var userCouldMatchRightDefinitions = AnswerAndExpectedSamePredictionRight(trainingWord, rightAnswer, userProposedAnswer);
            var userCouldMatchWrongDefinitions = AnswerAndExpectedDifferentPredictionRight(trainingWord,rightAnswer, userProposedAnswer);

            return userCouldMatchRightDefinitions || userCouldMatchWrongDefinitions;
        }
    }
}