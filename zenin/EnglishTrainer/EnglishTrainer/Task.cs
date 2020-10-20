using System;
using System.Collections.Generic;
using System.Data;

namespace EnglishTrainer
{
    public abstract class Task
    {
        public int WordsInTask { get;}
        public string ColumnToCheck { get;}
        
        protected Task(int wordsInTask, string columnToCheck)
        {
            WordsInTask = wordsInTask;
            ColumnToCheck = columnToCheck;
        }

        protected bool CheckIfSetIsSuitable(DataTable setOfWords)
        {
            return setOfWords.Rows.Count == WordsInTask;
        }
        
        protected bool CheckIfAnswersIsSuitable(string[] answers)
        {
            return answers.Length == WordsInTask;
        }
        
        public int CountNonRepeatedWordsVocabulary(Vocabulary vocabulary)
        {
            var count = 0;
            foreach (DataRow row in vocabulary.Words.Rows)
            {
                if ((int)row["repeated"] < 3)
                    count++;
            }
            return count;
        }
        
        public bool CheckIsEnoughWordsInVocabulary(Vocabulary vocabulary)
        {
            
            return CountNonRepeatedWordsVocabulary(vocabulary) >= WordsInTask;
        }
        
        public List<string> CheckAnswers(DataTable setOfWords, string[] answers)
        {
            List<string> repeated = new List<string>();
            for(int i = 0; i < setOfWords.Rows.Count; i++)
            {
                if (setOfWords.Rows[i][ColumnToCheck].ToString() == answers[i])
                    repeated.Add(setOfWords.Rows[i]["english"].ToString());
            }
            return repeated;
        }

        public List<string> CheckTask(DataTable setOfWords, string[] answers)
        {
            if (CheckIfSetIsSuitable(setOfWords) && CheckIfAnswersIsSuitable(answers))
            {
                return CheckAnswers(setOfWords, answers);
            }
            else
                return new List<string>();
        }
        public abstract DataTable CreateSetOfWords(Vocabulary vocabulary);

    }
}