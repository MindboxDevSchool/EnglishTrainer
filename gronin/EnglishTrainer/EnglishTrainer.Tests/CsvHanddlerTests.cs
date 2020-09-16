using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class CsvHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadFromCsv_correctTransformationToList()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName 
                          + "\\Test.csv";
            File.WriteAllText(path, "English,Russian,AmountOfSuccsessfulTranslations\r\nabc,abc,0\r\n");

            var list = CsvHandler.LoadFromCsv(path);
            
            Assert.AreEqual("abc",list[0].English);
            Assert.AreEqual("abc",list[0].Russian);
            Assert.AreEqual(0,list[0].AmountOfSuccsessfulTranslations);
        }
        
        [Test]
        public void WriteToCsv_CorrectTransformationFromList()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("abc","abc");
            list.Add(word1);
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName 
                          + "\\Test.csv";
            
            CsvHandler.WriteToCsv(list,path);
            
            var text = File.ReadAllText(path);
            Assert.AreEqual("English,Russian,AmountOfSuccsessfulTranslations\r\nabc,abc,0\r\n",
                        text);
        }
        
        [Test]
        public void LoadFromCsv_fileDoesntExist()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName 
                          + "\\Test.csv";

            Assert.Catch<ArgumentException>(() => CsvHandler.LoadFromCsv(path + "dasfasdf"));
        }
        
        [Test]
        public void WriteToCsv_fileDoesntExist()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName 
                          + "\\Test.csv";
            var list = new List<WordInDictionary>();
            
            Assert.Catch<ArgumentException>(() => CsvHandler.WriteToCsv(list,path + "dasfasdf"));
        }
    }
}