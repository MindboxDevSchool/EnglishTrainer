using System.IO;
using EnglishTrainer.App;

namespace EnglishTrainer.Domain
{
    public abstract class Excercise
    {
        protected int Length;
        public WordPair[] WordPairs { get; }

        protected Excercise(WordPair[] pairs)
        {
            WordPairs = pairs;
        }
        public abstract bool[] CheckCorrectness();
    }
}