using System;
using System.Collections.Generic;
using System.IO;

namespace EnglishTrainer.Display
{
    class Program
    {
        static void Main(string[] args)
        {
           // string filePath = @"C:\Users\Admin\RiderProjects\EnglishTrainer\EnglishTrainer.Display\dict.csv";
            Trainer.PopulateDictionary(DictionaryParser.DictionaryParser.ParseDictionary(DictionaryParser.DictionaryParser.FilePath));
            Dictionary<string, Word> dictionary = Trainer.GetDictionary();
            IDisplay display = new MenuDisplay();
            display.Display(dictionary, InitiateResult());
        }

        private static Result InitiateResult()
        {
            List<QuestionResult> questionResults = new List<QuestionResult>();
            Result result = new Result(questionResults);
            return result;
        }
    }
}