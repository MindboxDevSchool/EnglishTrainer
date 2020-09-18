using System.Collections;
using System.Collections.Generic;

namespace EnglishTrainer {
    public class Answers<T> : IEnumerable<T> {
        private readonly List<T> _answers;

        public Answers(List<T> answers) {
            _answers = answers;
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