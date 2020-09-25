using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageTrainer.model
{
    public abstract class WordDictionary
    {
        private Dictionary<string, string> _dictionary;

        public abstract Dictionary<string, string> Load(Language fromLanguage, Language toLanguage);

        public Maybe<string> LookUp(string word)
        {
            return _dictionary.ContainsKey(word)
                ? (Maybe<string>) new Maybe<string>.Some(_dictionary[word])
                : new Maybe<string>.None();
        }
        
        public string Sample()
        {
            return Sample(1).First();
        }
        
        public IEnumerable<string> Sample(int size)
        {
            if (_dictionary.Count < size) throw new ArgumentOutOfRangeException();
            return _dictionary.Keys.ToHashSet().Take(size);
        }
        
        public Maybe<string> Remove(string word)
        {
            return _dictionary.ContainsKey(word)
                ? (Maybe<string>) new Maybe<string>.Some(_dictionary[word])
                : new Maybe<string>.None();
        }
    }
}
