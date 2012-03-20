namespace DotNetScripting
{
    /// <summary>
    /// Public methods placed in this file are callable from the code executed by the Roslyn scripting engine.
    /// To expose Notepad++ interactions and utility methods to the scripts, add methods here.
    /// Also please add them to the wiki on GitHub.
    /// </summary>
    public class ScriptingSessionHost
    {
        private string currentLine;

        public void SetLine(string line)
        {
            currentLine = line;
        }

        public string GetLine()
        {
            return currentLine;
        }
    }
}