using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using EnglishTrainer.Services;
using EnglishTrainer.Vocabularies;

namespace TestEnglishTrainer.Services
{
    public class CSVService : IService
    {
        public List<Word> GetWords()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (TextReader reader = new StreamReader("../../../TestFiles/In/Vocabulary.csv",Encoding.GetEncoding("windows-1251")))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Configuration.Delimiter = ",";
                return csvReader.GetRecords<Word>().ToList();
            }
        }

        public void UpdateVocabulary(IEnumerable<Word> words)
        {
            using TextWriter writer = new StreamWriter("../../../TestFiles/Out/VocabularyAfterTest.csv", false, Encoding.GetEncoding("windows-1251"));
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.Configuration.Delimiter = ",";
                csv.WriteRecords(words);
            }
        }
    }
}