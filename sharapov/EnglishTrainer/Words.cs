using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer {
    public class Words : IEnumerable<Word> {
        private List<Word> WordsList { get; }

        public Words(List<Word> copyWordsList) {
            if (copyWordsList == null) {
                throw new ArgumentNullException($"{nameof(copyWordsList)}");
            }
            if (copyWordsList.Count <= 0) {
                throw new ArgumentException("Can't create Words from empty collection");
            }
            WordsList = new List<Word>(copyWordsList);
        }
        
        public IEnumerator<Word> GetEnumerator() {
            return WordsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public bool IsEmpty() {
            return !WordsList.Any();
        }
    }
}