using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EN_RUS_Trainer
{
    /* Я еще не умею работать с API Гугл или Яндекс-переводчика,
      поэтому сделаем вид, что слова парсятся из CSV-файла, 
      включенного в папку с библиотечкой. Пока их 15 для теста.
      В идеале хотелось бы получать случайный массив английских слов с сайта,
      например, wordgenerator, а затем подбирать к ним значение на русском
      или другом языке с помощью обращения к API переводчика.
    */
    public class CsvDictionaryGenerator
    {
        public static String GetDictSourcePath()
        {
            String filePath = Directory.GetParent(Environment.CurrentDirectory).Parent?.FullName
                              + "\\dict.csv";
            return filePath;
        }
        
        public static IEnumerable<String[]> ReadWordsFromCsv(String filePath)
        {
            var lines = File
                .ReadAllLines(filePath)
                .Select(x => x.Split(';'));
            return lines;
        }
        
        public static string[] GetArrayOfStringsFromCsv(IEnumerable<String[]> lines, int index)
        {
            int lineLength = lines.First().Count();
            var csv = lines
                .SelectMany(x => x)
                .Select((v, i) => new {Value = v, Index = i % lineLength})
                .ToArray();

            var strings = csv
                .Where(x => x.Index == index)
                .Select(x => x.Value)
                .ToArray();

            return strings;
        }
        
        public static string[] GetOriginalWordsFromCsv()
        {
            var filePath = GetDictSourcePath();
            var originalWords = GetArrayOfStringsFromCsv(ReadWordsFromCsv(filePath), 0);
            
            return originalWords;
        }
        
        public static string[] GetTranslationOfWordsFromCsv()
        {
            var filePath = GetDictSourcePath();
            var translatedWords = GetArrayOfStringsFromCsv(ReadWordsFromCsv(filePath), 1);
            return translatedWords;
        }
        
    }
}