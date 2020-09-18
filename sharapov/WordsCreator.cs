using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnglishTrainer {
    public static class WordsCreator {
        private const string Separator = ";";

        public static Words CreateFromCsv(string csvPath) {
            var extractedData = File.ReadAllLines(csvPath)
                .Where(row => row.Length > 0)
                .Select(CreateWord)
                .ToList();
            return new Words(extractedData);
        }

        private static Word CreateWord(string row) {
            var splintedRow = row.Split(Separator);
            var transaction = new Word(splintedRow[1], splintedRow[0]);
            return transaction;
        }
    }
}