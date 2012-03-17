namespace NppPluginNET
{
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