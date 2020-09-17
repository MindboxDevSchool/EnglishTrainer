namespace EnglishTrainer
{
    public class Trainer
    {
        public static void StartTrainer(int mode)
        {
            switch (mode)
            {
                case 0:
                    Sprint.SprintProcess(Input.GetWordsPairs());
                    break;
                case 1:
                    ManualTranslation.ManualTranslationProcess(Input.GetWordsPairs());
                    break;
            }
        }
    }
}