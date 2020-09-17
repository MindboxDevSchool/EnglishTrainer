using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnglishTrainer
{
    public class ManualTranslationTask : Task
    {
        public ManualTranslationTask() : base(10, "russian") {}

        public  override DataTable CreateSetOfWords(Vocabulary vocabulary)
        {
            var rand = new Random();
            var set = Vocabulary.CreateEmptyDataTable();

            if (CheckIsEnoughWordsInVocabulary(vocabulary))
            {
                while (set.Rows.Count < WordsInTask)
                {
                    var row = vocabulary.Words.Rows[rand.Next(vocabulary.Length)];
                    if ((int) row["repeated"] < 3 &&
                        Trainer.FindIndexOfStringInColumn(set, row["english"].ToString(), "english") != -1)
                        set.Rows.Add(row["english"], row["russian"]);
                }
            }

            return set;
        }
    }
}