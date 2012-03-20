namespace DotNetScripting.ScriptingEngines
{
    internal interface IScriptingEngineRunner
    {
        void RunBefore();
        string RunLine(string line);
        void RunAfter();
    }
}