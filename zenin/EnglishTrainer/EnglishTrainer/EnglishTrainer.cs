using System;
using System.Collections.Generic;
using System.Data;

namespace EnglishTrainer
{
    public class Trainer
    {
        public Vocabulary Vocabulary { get; private set; }
        private enum Status
        {
            WaitingTask,
            TaskInProgress
        }
        private Status _status = Status.WaitingTask;

        public Trainer(Vocabulary vocabulary)
        {
            Vocabulary = vocabulary;
        }
        
        public static int FindIndexOfStringInColumn(DataTable table, string value, string column)
        {
            var index = -1;
            foreach (DataRow row in table.Rows)
            {
                if (row[column].ToString() == value)
                    index = table.Rows.IndexOf(row);
            }

            return index;
        }

        public void UpdateRepeatsOfVocabulary(List<string> repeatedWords)
        {
            foreach (var word in repeatedWords)
            {
                foreach (DataRow row in Vocabulary.Words.Rows)
                {
                    if (row["english"].ToString() == word)
                        row.SetField("repeated", (int)row["repeated"] + 1);
                }
            }
        }
        //понимаю, что ниже следовало бы использовать optional, но пока еще не до конца с ним разобрался
        public DataTable StartTask(Task task)
        {
            if (_status == Status.WaitingTask)
            {
                _status = Status.TaskInProgress;
                return task.CreateSetOfWords(Vocabulary);
            }
            else
                throw new MethodAccessException();
        }
        
        public void CheckTask(Task task, string[] answers, DataTable setOfWords)
        {
            if (_status == Status.TaskInProgress)
            {
                _status = Status.WaitingTask;
                UpdateRepeatsOfVocabulary(task.CheckTask(setOfWords, answers));
            }
            else
                throw new MethodAccessException();
        }
    }
}