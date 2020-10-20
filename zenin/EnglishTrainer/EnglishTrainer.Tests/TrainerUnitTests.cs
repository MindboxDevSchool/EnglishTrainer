using System.Collections.Generic;
using System.Data;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class TrainerUnitTests
    {
        [Test]
        public void ValueFromDataTable_FindIndexOfStringInColumn_CorrectIndex()
        {
            var table = new DataTable();
            table.Columns.Add("1", typeof(string));
            table.Columns.Add("2", typeof(string));
            table.Rows.Add("one", "two");
            table.Rows.Add("three", "four");

            var index = Trainer.FindIndexOfStringInColumn(table, "four", "2");
            
            Assert.AreEqual(1, index);
        }
        
        [Test]
        public void ValueNotFromDataTable_FindIndexOfStringInColumn_IndexIsMinusOne()
        {
            var table = new DataTable();
            table.Columns.Add("1", typeof(string));
            table.Columns.Add("2", typeof(string));
            table.Rows.Add("one", "two");
            table.Rows.Add("three", "four");

            var index = Trainer.FindIndexOfStringInColumn(table, "five", "2");
            
            Assert.AreEqual(-1, index);
        }
        
        [Test]
        public void TrainerWithFileWithEnglishAndRussianWords_UpdateRepeatsOfVocabulary_RepeatsOfWordsIncreasesByOne()
        {
            Vocabulary vocabulary = new Vocabulary("words.csv");
            var trainer = new Trainer(vocabulary);
            List<string> repeatedWords = new List<string>();
            repeatedWords.Add("one"); 
            repeatedWords.Add("two");

            trainer.UpdateRepeatsOfVocabulary(repeatedWords);
            
            Assert.AreEqual(0, (int)trainer.Vocabulary.Words.Rows[0]["repeated"]);
            Assert.AreEqual(1, (int)trainer.Vocabulary.Words.Rows[2]["repeated"]);
            Assert.AreEqual(1, (int)trainer.Vocabulary.Words.Rows[3]["repeated"]);
        }
    }
}