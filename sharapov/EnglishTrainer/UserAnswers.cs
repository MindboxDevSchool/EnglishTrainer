using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnglishTrainer {
    public class UserAnswers<T> : IEnumerable<T> {
        private readonly ReadOnlyCollection<T> _answers;

        public UserAnswers(IList<T> answers) {
            _answers = new ReadOnlyCollection<T>(answers);
        }

        public IEnumerator<T> GetEnumerator() {
            return _answers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count() {
            return _answers.Count;
        }
    }
}