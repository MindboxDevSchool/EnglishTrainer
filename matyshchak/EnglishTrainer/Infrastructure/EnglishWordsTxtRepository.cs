using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer;

namespace DataAccess
{
    public class EnglishWordsTxtRepository : IEnglishWordsRepository
    {
        private readonly string _txtFilePath;
        private readonly IEnglishWordParser _englishWordParser;

        public EnglishWordsTxtRepository(string txtFilePath, EnglishWordParser englishWordParser)
        {
            _txtFilePath = txtFilePath;
            _englishWordParser = englishWordParser;
        }

        public IEnumerable<EnglishWord> GetAllWords()
        {
            return File.ReadAllLines(_txtFilePath)
                .Select(line => _englishWordParser.Parse(line));
        }
        
        public IEnumerable<EnglishWord> GetRandomNotLearnedWords(int numberOfWords)
        {
            return GetAllWords().OrderBy(arg => Guid.NewGuid()).Take(numberOfWords).ToList();
        }

        public void UpdateWordsStatus(IEnumerable<EnglishWord> words)
        {
            throw new System.NotImplementedException();
        }
    }
}