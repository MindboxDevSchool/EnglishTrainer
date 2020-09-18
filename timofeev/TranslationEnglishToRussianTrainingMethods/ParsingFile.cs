namespace TranslationEnglishToRussianTrainingMethods
{
    public class Parsing
    {
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }

        public static Parsing ParseRow(string row)
        {
            var columns = row.Split(';');
            return new Parsing()
            {
                EnglishWord = columns[0],
                RussianWord = columns[1]
            };
        }
    }
}