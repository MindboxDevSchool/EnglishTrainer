using System;

namespace EnglishTrainer {
    //Bijection mapping, one-to-one correspondence between engDefinition and rusDefinition.
    //engDefinition <=> rusDefinition
    public class Word {
        public string RusDefinition { get; private set; }
        public string EngDefinition { get; }

        public Word(string rusDefinition, string engDefinition) {
            if (string.IsNullOrEmpty(rusDefinition)) {
                throw new ArgumentException($"{nameof(rusDefinition)} null or empty");
            }
            if (string.IsNullOrEmpty(engDefinition)) {
                throw new ArgumentException($"{nameof(engDefinition)} null or empty");
            }
            RusDefinition = rusDefinition;
            EngDefinition = engDefinition;
        }

        private bool Equals(Word other) {
            return RusDefinition == other.RusDefinition && EngDefinition == other.EngDefinition;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Word) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(RusDefinition, EngDefinition);
        }
        
        public void ReplaceRusDefinition(string newRusDefinition) {
            RusDefinition = newRusDefinition;
        }
    }
}