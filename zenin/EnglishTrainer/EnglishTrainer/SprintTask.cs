using System;
using System.Collections.Generic;
using System.Data;

namespace EnglishTrainer
{
    public class SprintTask : Task
    {
        public SprintTask() : base(15, "correct") {}

        public override DataTable CreateSetOfWords(Vocabulary vocabulary)
        {
            var rand = new Random();
            var set = Vocabulary.CreateEmptyDataTable();
            set.Columns.Add("correct", typeof(string));
            
            if(CheckIsEnoughWordsInVocabulary(vocabulary))
                while (set.Rows.Count < WordsInTask)
                {
                    var row = vocabulary.Words.Rows[rand.Next(vocabulary.Length)];
                    if ((int) row["repeated"] < 3 &&
                        Trainer.FindIndexOfStringInColumn(set, row["english"].ToString(), "english") != -1)
                    {
                        if(rand.Next(1) == 0)
                            set.Rows.Add(row["english"], row["russian"], "true");
                        else
                            set.Rows.Add(row["english"], 
                                vocabulary.Words.Rows[rand.Next(vocabulary.Length)]["russian"], "false");
                    }
                }

            return set;
        }
    }
}