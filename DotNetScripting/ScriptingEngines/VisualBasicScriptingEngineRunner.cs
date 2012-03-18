//using Roslyn.Scripting.VisualBasic; DOES NOT EXIST

namespace NppPluginNET.ScriptingEngines
{
    /// <summary>
    /// This class was intended to handle running VB.NET scripts,
    /// but it seems Roslyn doesn't contain a VB.NET ScriptingEngine.
    /// If they add one in the fututre, the implementation would go here.
    /// </summary>
    internal class VisualBasicScriptingEngineRunner : IScriptingEngineRunner
    {
        public void RunBefore()
        {
            throw new System.NotImplementedException();
        }

        public string RunLine(string line)
        {
            throw new System.NotImplementedException();
        }

        public void RunAfter()
        {
            throw new System.NotImplementedException();
        }
    }
}