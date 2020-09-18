using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer;

namespace DataAccess
{
    public static class WordsFromFileParser
    {
        public static IReadOnlyList<Word> Parse(string txtFilePath,
            Func<string, Optional<Word>> funcToParseWordFromLine)
        {
            return File.ReadAllLines(txtFilePath)
                .Select(funcToParseWordFromLine)
                .Where(optionalWord => optionalWord.HasValue)
                .Select(optionalWord => optionalWord.Value)
                .ToList();
        }
    }
}