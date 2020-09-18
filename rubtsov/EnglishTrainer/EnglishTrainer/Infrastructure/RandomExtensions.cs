using System;
using System.Collections.Generic;

namespace EnglishTrainer.Infrastructure
{
    public static class RandomExtensions
    {
        public static void Shuffle<T> (this Random random, List<T> wordsTranslations)
        {
            var n = wordsTranslations.Count;
            while (n > 1) 
            {
                var k = random.Next(n--);
                var temp = wordsTranslations[n];
                wordsTranslations[n] = wordsTranslations[k];
                wordsTranslations[k] = temp;
            }
        }
    }
}