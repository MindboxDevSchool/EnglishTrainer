using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EnglishTrainer;

namespace DataAccess
{
    public static class WordFromStringParser
    {
        public static Optional<Word> Parse(string str)
        {
            var noSpacesLine = Regex.Replace(str, "\\s*", "");
            var splitLine = Regex.Split(noSpacesLine, "(\\[[^\\]]*\\])|—")
                .Where(s => s != "")
                .ToList();

            if (splitLine.Count < 3)
                return new Optional<Word>();
            
            var spelling = splitLine[0];
            var transcription = splitLine[1];
            var translations = splitLine[2].Split("/").ToList();
            
            return new Optional<Word>(new Word(spelling, translations));
        }
    }
}