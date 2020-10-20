using System.Data;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class VocabularyUnitTests
    {
        [Test]
        public void FileWithEnglishAndRussianWords_FromCSVtoDataTable_CorrectFirstAndSecondRowOfFile()
        {
            var fileName = "words.csv";

            var table = Vocabulary.FromCSVtoDataTable(fileName);
            
            Assert.AreEqual("he", table.Rows[0]["english"].ToString());
            Assert.AreEqual("он", table.Rows[0]["russian"].ToString());
            Assert.AreEqual("she", table.Rows[1]["english"].ToString());
            Assert.AreEqual("она", table.Rows[1]["russian"].ToString());
        }

        [Test] public void IncorrectFile_FromCSVtoDataTable_EmptyDataTable()
        {
            var fileName = "wrong.csv";

            var table = Vocabulary.FromCSVtoDataTable(fileName);
            
            Assert.AreEqual(0, table.Rows.Count);
        }
    }
}