namespace Assets.Source.Model.Pause
{
    public interface IPauseManger : IPauseRegister, IPauseUnRegister
    {
        public void PauseAll();
        public void ResumeAll();
    }
}