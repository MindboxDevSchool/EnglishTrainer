using System.Collections.Generic;

namespace EnglishTrainer.Infrastructure
{
    public interface IWordsLoader
    {
        public Dictionary<string, string> LoadWords { get; }
    }
}