using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace NppPluginNET.ScriptingEngines
{
    internal class CSharpScriptingEngineRunner : IScriptingEngineRunner
    {
        private readonly NppCommands nppCommands;
        private readonly string scriptBefore;
        private readonly string scriptLine;
        private readonly string scriptAfter;
        private readonly ScriptingSessionHost scriptingSessionHost;
        private readonly ScriptEngine scriptEngine;
        private readonly Session scriptEngineSession;
        private readonly IEnumerable<string> importedNamespaces;

        public CSharpScriptingEngineRunner(NppCommands nppCommands, string scriptBefore, string scriptLine, string scriptAfter)
        {
            this.nppCommands = nppCommands;
            this.scriptBefore = scriptBefore;
            this.scriptLine = scriptLine;
            this.scriptAfter = scriptAfter;
            scriptingSessionHost = new ScriptingSessionHost();
            importedNamespaces = new[]
                                     {
                                         "System",
                                         "System.Linq",
                                         "System.Collections",
                                         "System.Collections.Generic",
                                         "System.Text.RegularExpressions",
                                         "NppPluginNET"
                                     };

            scriptEngine = new ScriptEngine(new[]
                                                {
                                                    typeof(ScriptingSessionHost).Assembly,
                                                    typeof(Console).Assembly,
                                                    typeof(IEnumerable<>).Assembly,
                                                    typeof(IQueryable<>).Assembly,
                                                    typeof(Regex).Assembly
                                                }, importedNamespaces
                );
            scriptEngineSession = Session.Create(scriptingSessionHost);
            InitializeUsings();
        }

        public void RunBefore()
        {
            scriptEngine.Execute("string _ = null;", scriptEngineSession);
            scriptEngine.Execute(scriptBefore, scriptEngineSession);
        }

        public string RunLine(string line)
        {
            scriptingSessionHost.SetLine(line);
            scriptEngine.Execute("_ = GetLine();", scriptEngineSession);
            scriptEngine.Execute(scriptLine, scriptEngineSession);
            scriptEngine.Execute("SetLine(_);", scriptEngineSession);
            return scriptingSessionHost.GetLine();
        }

        public void RunAfter()
        {
            scriptEngine.Execute(scriptAfter, scriptEngineSession);
        }

        private void InitializeUsings()
        {
            foreach (var importedNamespace in importedNamespaces)
            {
                scriptEngine.Execute(string.Format("using {0};", importedNamespace), scriptEngineSession);
            }
        } 
    }
}