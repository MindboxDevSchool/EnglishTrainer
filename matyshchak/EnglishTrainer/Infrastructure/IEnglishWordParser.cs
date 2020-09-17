using EnglishTrainer;

namespace DataAccess
{
    public interface IEnglishWordParser
    {
        public EnglishWord Parse(string str);
    }
}