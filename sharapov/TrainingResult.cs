// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace EnglishTrainer {
//     // public class TrainingResult : IEnumerable<WordLearningResult> {
//     //     private readonly List<WordLearningResult> _resultContainer;
//     //
//     //     public TrainingResult(List<WordLearningResult> resultContainer) {
//     //         _resultContainer = resultContainer;
//     //     }
//     //
//     //     // public void Add(Word word, bool isRightAnswer) {
//     //     //     _resultContainer.Add(new WordLearningResult(word, isRightAnswer));
//     //     // }
//     //
//     //     // //TODO use Optional<T> boilerplate for bool?
//     //     public bool? IsProgressWithLearningWord(Word word) {
//     //         if (word == null) {
//     //             throw new ArgumentNullException(nameof(word));
//     //         }
//     //
//     //         var findWord = _resultContainer.Find(w => w.Value.Equals(word));
//     //         return findWord.WasSuccessfulRepeated;
//     //     }
//     //
//     //     IEnumerator<WordLearningResult> IEnumerable<WordLearningResult>.GetEnumerator() {
//     //         return _resultContainer.GetEnumerator();
//     //     }
//     //
//     //     public IEnumerator GetEnumerator() {
//     //         return _resultContainer.GetEnumerator();
//     //     }
//     // }
// }