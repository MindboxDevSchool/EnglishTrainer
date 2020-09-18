using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer {
    
    public class Words : IEnumerable<Word> {
        private List<Word> WordsContainer { get; }

        public Words(List<Word> wordsContainer) {
            WordsContainer = wordsContainer;
        }
        
        public static Words CreateFrom(Words copyWords) {
            return new Words(new List<Word>(copyWords));
        }
        
        public IEnumerator<Word> GetEnumerator() {
            return WordsContainer.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public bool IsEmpty() {
            return !WordsContainer.Any();
        }

        public void ReplaceRusDefinition(string engDefinition, string newRusDefinition) {
            var wordForReplaceRusDefinition = WordsContainer.Find(word => word.EngDefinition == engDefinition);
            WordsContainer.Remove(wordForReplaceRusDefinition);
            WordsContainer.Add(new Word(engDefinition,  newRusDefinition));   
        }
        
    }
}