using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer.Infrastructure;
using NUnit.Framework;

namespace EnglishTrainerTests
{
    public class RandomExtensionsTests
    {
        [Test] public void OrdinaryWordsSequence_InitialWordsSequenceDifferFromShuffledWordsSequence()
        {
            var randomizer = new Random();
            List<string> words = new List<string> {"black", "white", "red", "green", "blue"};
            List<string> shuffledWords = words;
            
            randomizer.Shuffle(shuffledWords);
            var sequenceEqual = words.SequenceEqual(shuffledWords);
            
            Assert.True(sequenceEqual);
        }
    }
}