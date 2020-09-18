using System;

namespace EnglishTrainer {
    public class ResultForUpdateStorage {
        public Word Word { get; }
        public bool IsAnswerWasRight { get; }

        public ResultForUpdateStorage(Word word, bool isAnswerWasRight) {
            this.Word = word;
            IsAnswerWasRight = isAnswerWasRight;
        }

        protected bool Equals(ResultForUpdateStorage other) {
            return Equals(Word, other.Word) && IsAnswerWasRight == other.IsAnswerWasRight;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResultForUpdateStorage) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Word, IsAnswerWasRight);
        }
    }

}