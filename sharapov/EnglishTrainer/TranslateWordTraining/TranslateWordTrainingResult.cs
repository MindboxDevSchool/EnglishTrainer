using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.TranslateWordTraining {
    public class TranslateWordTrainingResult : IEnumerable<WordLearnInfo> {
        private readonly List<WordLearnInfo> _trainedWordsInfo;

        private TranslateWordTrainingResult(List<WordLearnInfo> learnInfoWords) {
            _trainedWordsInfo = learnInfoWords;
        }

        //fabric method
        public static TranslateWordTrainingResult Create(IEnumerable<string> answers, Words trainingWords) {
            List<WordLearnInfo> learnInfoWords = new List<WordLearnInfo>();
            var pairAnswersAndExpectedEngWords = answers.Zip(trainingWords,
                (ans, word) => new {userRusAnswer = ans, expectedWord = word});
            foreach (var pair in pairAnswersAndExpectedEngWords) {
                if (pair.userRusAnswer.Equals(pair.expectedWord.RusDefinition)) {
                    learnInfoWords.Add(new WordLearnInfo(pair.expectedWord, pair.userRusAnswer, true));
                }
                else {
                    learnInfoWords.Add(new WordLearnInfo(pair.expectedWord, pair.userRusAnswer, false));
                }
            }

            return new TranslateWordTrainingResult(learnInfoWords);
        }

        public IEnumerator<WordLearnInfo> GetEnumerator() {
            return _trainedWordsInfo.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}