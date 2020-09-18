using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper.Configuration;

namespace EnglishTrainer.Vocabularies
{
    public class Word
    {
        private int numberOfCorrectlyTranslationsByUser;
        public string Value { get; set; }
        public string Translation { get; set; }
        public bool IsLearnedWord => NumberOfCorrectlyTranslationsByUser > 3;
        public int NumberOfCorrectlyTranslationsByUser {
            get => numberOfCorrectlyTranslationsByUser;
            set
            {
                if (NumberOfCorrectlyTranslationsByUser < 0)
                    throw new ArgumentException("Количество изученных слов не может быть отрицательным");
                numberOfCorrectlyTranslationsByUser = value;
            }
        }
    }
}