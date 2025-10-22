namespace UniTemplate.LogServices
{
    using UnityEngine;

    public class LogServicesManager : ILogServices
    {
        public void LogCallerInfor(
            [System.Runtime.CompilerServices.CallerLineNumber] int    line       = 0,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath]   string filePath   = ""
        )
        {
            Debug.Log($"{line} :: {memberName} :: {filePath}");
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void LogException(string message)
        {
            Debug.LogException(new System.Exception(message));
        }
    }
}