using System;
using System.Data;
using System.IO;

namespace EnglishTrainer
{
    public class Vocabulary
    {
        public DataTable Words { get; }
        public int Length { get; }
        
        public Vocabulary(string fileName)
        {
            Words = FromCSVtoDataTable(fileName);
            Length = Words.Rows.Count;
        }
        
        public static DataTable CreateEmptyDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("english", typeof(string));
            table.Columns.Add("russian", typeof(string));
            return table;
        }
        public static DataTable FromCSVtoDataTable(string fileName)
        {
            //string path = System.IO.Directory.GetCurrentDirectory();
            var path = @"C:\Users\ilyaz\RiderProjects\EnglishTrainer\zenin\EnglishTrainer\EnglishTrainer\";
            DataTable table = CreateEmptyDataTable();
            table.Columns.Add("repeated", typeof(int));
            
            if(File.Exists(path + fileName))
            {
                var reader = new StreamReader(path + fileName);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if(values.Length == 2)
                        table.Rows.Add(values[0], values[1], 0);
                }
            }
            
            return table;
        }
    }
}