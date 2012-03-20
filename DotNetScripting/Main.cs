using System;
using System.IO;
using System.Reflection;
using NppPluginNET;

namespace DotNetScripting
{
    class Main
    {
        private static DotNetScriptingPlugin plugin;

        public static string PluginName
        {
            get { return DotNetScriptingPlugin.APP_NAME; }
        }

        static Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += LoadFromPluginSubFolder;
        }

        static Assembly LoadFromPluginSubFolder(object sender, ResolveEventArgs args)
        {
            var pluginPath = typeof(Main).Assembly.Location;
            var pluginName = Path.GetFileNameWithoutExtension(pluginPath);
            var pluginSubFolder = Path.Combine(Path.GetDirectoryName(pluginPath), pluginName);
            var assemblyPath = Path.Combine(pluginSubFolder, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath))
                return Assembly.LoadFrom(assemblyPath);
            return null;
        }

        private static void Initialize()
        {
            if(plugin == null)
                plugin = new DotNetScriptingPlugin(PluginBase.nppData, new SettingsManager(PluginBase.nppData, PluginName));
        }

        internal static void CommandMenuInit()
        {
            Initialize();
            plugin.CommandMenuInit();
        }

        internal static void SetToolBarIcon()
        {
            Initialize();
            plugin.SetToolBarIcon();
        }

        internal static void PluginCleanUp()
        {
            if(plugin != null)
                plugin.PluginCleanUp();
        }
    }
}