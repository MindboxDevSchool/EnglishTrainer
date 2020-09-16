﻿using System.Collections.Generic;
using EnglishTrainer;
using NUnit.Framework;

namespace Sprint.Tests
{
    public class WordsPairs_Tests
    {
        [Test]
        public void GetNumberOfWordsPairs_5Pairs()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "один");
            WordsPair wordsPair2 = new WordsPair("two", "два");
            WordsPair wordsPair3 = new WordsPair("three", "три");
            WordsPair wordsPair4 = new WordsPair("four", "четыре");
            WordsPair wordsPair5 = new WordsPair("five", "пять");
            List<WordsPair> wordsPairsList = new List<WordsPair>();
            wordsPairsList.Add(wordsPair1);
            wordsPairsList.Add(wordsPair2);
            wordsPairsList.Add(wordsPair3);
            wordsPairsList.Add(wordsPair4);
            wordsPairsList.Add(wordsPair5);
            WordsPairs wordsPairs = new WordsPairs(wordsPairsList);
            // act
            int result = 5;
            // assert
            Assert.AreEqual(result, WordsPairs.GetNumberOfWordsPairs());
        }
    }
}