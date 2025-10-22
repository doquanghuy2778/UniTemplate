namespace UniTemplate.LogServices
{
    public interface ILogServices
    {
        public void LogCallerInfor(int line, string memberName, string sourceFilePath);
        public void LogError(string    message);
    }
}